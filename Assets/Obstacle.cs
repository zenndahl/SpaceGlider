using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody2D rb;
    private float speed = 2;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.gameOver == true){
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    void SetDirection(){
        direction = (Vector2)Player.GetPlayerPosition() - rb.position;
    }

    // Update is called once per frame
    void Update(){
        if(GameManager.gameOver == true){
            Destroy(gameObject);
        }
        float distancePerFrame = speed * Time.deltaTime;
        transform.Translate(direction.normalized * distancePerFrame);
        if(transform.position.x >= 10 || transform.position.x <= -10){
            Destroy(gameObject);
        }
        if(transform.position.y >= 10 || transform.position.y <= -10){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Hit");
            Player.health -= damage;
        }
    }
}
