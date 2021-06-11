using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleContoller : MonoBehaviour
{
    public GameObject Planet;
    private float speed;

    void Start()
    {
        speed = 55;
    }
   
    void FixedUpdate()
    {
        Orbit();
    }
    void Orbit()
    {
        transform.RotateAround(Planet.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
