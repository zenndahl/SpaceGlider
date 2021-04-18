using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private static Vector3 pos;
    public static int points;
    public static int health;
    public float moveSpeed = 5;
    public float multiplier = 1;
    float dirX;
    float dirY;
    // Start is called before the first frame update
    void Start(){
        pos = transform.position;
        points = 0;
        health = 100;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
            Debug.Log("Game Over");
            GameManager.gameOver = true;
        }

        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            transform.position = touchPosition;
        }
        // dirX = Input.acceleration.x * moveSpeed;
        // dirY = Input.acceleration.y * moveSpeed;
        // Debug.Log(dirY);
        // if(dirY >= 0) multiplier = 3f;
    }

    private void FixedUpdate() {
        //rb.velocity = new Vector2(dirX, dirY * multiplier);
    }

    public static Vector3 GetPlayerPosition(){
        return pos;
    }
}
