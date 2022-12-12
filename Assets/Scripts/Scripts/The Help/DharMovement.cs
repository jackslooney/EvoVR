using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DharMovement : MonoBehaviour
{
    //speed of the target
    public float _speed = 5f;
    //set the initial direction of the target
    public Vector3 direction = Vector3.left;
    //the bounds of the target movement
    public float bound = 10f;
    void Update()
    {
        transform.Translate(direction * _speed * Time.deltaTime);
        if(transform.position.z >= bound || transform.position.z <= -bound) { direction = -direction; }
    }
}