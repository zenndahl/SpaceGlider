using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    Vector2 startPosition;
    float startZ;    

    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    float clippingPlane => (cam.transform.position.z + (distanceFromTarget> 0? cam.farClipPlane : cam.nearClipPlane));
    float distanceFromTarget => transform.position.z - target.position.z;
    float parallaxFactor => Mathf.Abs(distanceFromTarget)/clippingPlane;

    private void Start() {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    private void Update() {
        if(target == null) return;
        //Parallax funciona com a formula: origin + (travel * parallaxFacttor)
        Vector2 newPos = startPosition + (travel * parallaxFactor);
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
