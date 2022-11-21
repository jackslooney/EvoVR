using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Asteroid : MonoBehaviour
{

    /*public enum element { Water, Carbon, Oxygen, Hydrogen };*/
    /*public bool containsWater = false;
    public bool containsCarbon = false;*/

    [SerializeField]
    private Element elementPresent = new Element();

    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private bool isMoving = true;

    //Private Variables
    /*private List<element> elements = new List<element>() {element.Water, element.Carbon, element.Oxygen};*/
    private int spawnDestroyVal = 30;

    private void Awake()
    {
        setElementPresent();
    }
    // Update is called once per frame
    void Update()
    {
        MoveTowardsCenter();
        
        DestroyOutOfBounds();
    }

    /* Move the asteroid in the -x direction */
    private void MoveTowardsCenter()
    {
        if(isMoving)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
       /* transform.Translate(Vector3.right * Time.deltaTime * speed);*/
        
    }

    public void toggleMoving()
    {
        isMoving = !isMoving;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Some kind of interaction triggered on collision with the playerPlanet
        if (other.gameObject.GetComponent<PlayerPlanet>())
        {
            PlayerPlanet playerPlanet = other.gameObject.GetComponent<PlayerPlanet>();
            playerPlanet.setImpactedTrue(gameObject);

            Destroy(gameObject);
        }
    }

    private void DestroyOutOfBounds()
    {
        if ((transform.position.x > spawnDestroyVal || transform.position.x < -spawnDestroyVal) || (transform.position.z > spawnDestroyVal || transform.position.z < -spawnDestroyVal))
        {
            Destroy(this.gameObject);
        }
    }

    /* Getters and Setters for the Elements */
    
    private void setElementPresent()
    {
        elementPresent.setElementSelected();
    }

    //returns the element present
    public Element.element getElementPresent()
    {
        return elementPresent.getElementSelected();
    }

    public string getElementPresentAsString()
    {
        return elementPresent.getElementSelectedAsString();
    }


    
}
