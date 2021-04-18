using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
            if(touch.phase == TouchPhase.Ended) rb.velocity = Vector2.zero;
        }
    }
}
