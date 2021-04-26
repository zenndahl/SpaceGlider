using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 direction;
    public GameObject explosionEffect;
    private Rigidbody2D rb;
    private float speed = 2;
    public int damage = 50;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    void SetDirection(){
        direction = (Vector2)Player.GetPlayerPosition() - rb.position;
    }

    // Update is called once per frame
    void Update(){
        float distancePerFrame = speed * Time.deltaTime;
        transform.Translate(direction.normalized * distancePerFrame);

        //checando se saiu da tela
        if(transform.position.x >= 6 || transform.position.x <= -6){
            GameManager.points++;
            Destroy(gameObject);
        }
        if(transform.position.y >= 9 || transform.position.y <= -9){
            GameManager.points++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Player.health -= damage;
            Player.damaged = true;
            GameObject effect =  Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1);
        }
    }
}
