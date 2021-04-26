using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform target;
    public float offset = 0.3f;
  
    void Update () 
    {
        if(target == null) return;
        transform.position = new Vector3 (target.position.x * offset, target.position.y * offset); // Camera follows the player with specified offset position
    }

    
}
