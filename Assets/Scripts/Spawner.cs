using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    private float timer;
    private float initialCount;
    // Start is called before the first frame update
    void Start(){
        GenerateCountTime();
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
