using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float timer;
    public float initialCount = 3;
    // Start is called before the first frame update
    void Start(){
        initialCount = 3;
    }

    void GenerateCountTime(){
        int initialCount = Random.Range(1, 10);
        timer = initialCount;
    }

    // Update is called once per frame
    void Update(){
        
        int obstacleIndex = Random.Range(0, obstacles.Length);
        if(timer <= 0){
            Instantiate(obstacles[obstacleIndex], transform.position, Quaternion.identity);
            GenerateCountTime();
        }
        else{
            timer -= Time.deltaTime;
        }
    }
}
