using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{


    [SerializeField]
    private Transform target;
    [SerializeField]
    private int speed;


    private bool isMoving = true;
    // Update is called once per frame
    void Update()
    {
        if(isMoving) { transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime); }
    }

    /* Activating and Deactivating movement */

    public void setIsMovingFalse()
    {
        if (!isMoving) { return; }
        isMoving = false;
    }

    public void setIsMovingTrue()
    {
        if (isMoving) { return; }
        isMoving = true;
    }





}
