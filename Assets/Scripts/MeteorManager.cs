using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MeteorManager : MonoBehaviour
{
    [Header("Prefab Timeeee")]
    public GameObject prefab;
    [Header("List of Asteroids")]
    public List<GameObject> asteroids = new List<GameObject>();

    public bool stopSpawn = false;
    public float spawnTimer;
    public float spawnDelay;

    [Header("Change the spawn timer range")]
    public float maxTime;
    public float minTime;

    [Header("Asteroid Spawn Radius")]
    [SerializeField]
    private float spawnRadius = 15f;

    [Header("Rotation Range Change")]
    [SerializeField]
    private float xRotationRange = 10;
    [SerializeField]
    private float zRotationRange = 10;
    [Space]
    [SerializeField]
    private float ySpawnRotation = -45;
    private float zSpawnRotation = 0;
    private float xSpawnRotation = 0;

    [Header("Extra Shit")]
    public Vector3 spawnPos;
    public Quaternion spawnRotation;
    [SerializeField]
    private float angleInRadians = 0;
    [Space]
    [Header("UI Shit")]
    [SerializeField]
    private WristUI wristUI;

    //Private Variables
    

    // Start is called before the first frame update
    private void Start()
    {
        wristUI = GameObject.FindObjectOfType<Canvas>().GetComponent<WristUI>();
        spawnDelay = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        /*Invoke("SpawnAsteroid", spawnTimer);*/
        //spawnPos = new Vector3(-13, 5, Random.Range(-zSpawnRange, zSpawnRange));
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnDelay)
        {
            spawnAsteroid();
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnRotation = new Quaternion(0, Random.Range(-yRotationRange, yRotationRange), Random.Range(-zRotationRange, zRotationRange), 0);
            

            Instantiate(prefab, spawnPos, spawnRotation);
            


        }*/
    }

    public void spawnAsteroid()
    {
        fixAsteroidAngle();
        Quaternion spawnAngle = Quaternion.Euler(xSpawnRotation, ySpawnRotation, zSpawnRotation);
        //Randomize the spawnPosition along the spawnRadius
        angleInRadians = iterateRadians(angleInRadians);
        float spawnPosX = spawnRadius * Mathf.Cos(angleInRadians) + transform.position.x;
        float spawnPosZ = spawnRadius * Mathf.Sin(angleInRadians) + transform.position.z;
        spawnPos = new Vector3(spawnPosX, transform.position.y, spawnPosZ);
        /*Debug.Log(spawnAngle.z + " " + spawnAngle.y);*/
        GameObject o = Instantiate(prefab, spawnPos, spawnAngle);
        asteroids.Add(o);
        spawnDelay = Random.Range(minTime, maxTime);
        spawnTimer = 0;
        //o.GetComponent<Rigidbody>().velocity = Vector3.forward;


    }

    private void fixAsteroidAngle()
    {
        xSpawnRotation = Random.Range(-xRotationRange, xRotationRange);
        ySpawnRotation = ySpawnRotation - 45;
        zSpawnRotation = Random.Range(-zRotationRange, zRotationRange);
        Debug.Log(xSpawnRotation + " " + ySpawnRotation + " " + zSpawnRotation);
    }
    
    private float iterateRadians(float radians)
    {
        
        radians += (Mathf.PI / 4);
        if (radians >= ((2*Mathf.PI) + 1) && radians <= ((2 * Mathf.PI) - 1))
        {
            Debug.Log("Angle Reset");
            radians = 0f;
        }
        Debug.Log("Radians added " + radians);
        return radians;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, spawnRadius);
        Handles.DrawWireDisc(transform.position, new Vector3(0, 1, 0), spawnRadius);
    }
}
