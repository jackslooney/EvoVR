using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerPlanet : MonoBehaviour
{
    public AudioClip _clip;
    [Header("Positional Information")]
    [SerializeField]
    public Vector3 planetPosition;
    [SerializeField]
    public GameObject star;

    [Header("Planet Temperature")]
    [SerializeField]
    private float temperature;

    [Header("Lock the Y Axis of this planet")]
    public bool lockPos = true;
    [Header("Add water to this planet")]
    [SerializeField]
    private bool isWatered;
    [Header("Add Humidity to the this planet")]
    [SerializeField]
    private bool isHumid;

    [Header("If the planet has been impacted recently")]
    [SerializeField]
    private bool isImpacted;
    [Space]
    [Header("All of the Elements on the Planet")]
    [SerializeField]
    public List<Element> elementsOnPlanet = new List<Element>();
    /*public List<Hydrogen> hydrogenOnPlanet = new List<Hydrogen>();
    public List<Oxygen> oxygenOnPlanet = new List<Oxygen>();*/
    [Header("All of the Compounds on the Planet")]
    [SerializeField]
    public List<ChemicalCompound> compoundsOnPlanet = new List<ChemicalCompound>();
    /* [SerializeField]
     private GameObject self;*/

    /* All Private Variables */
    //Water Material
    private Material waterPlanet;
    private Material rockPlanet;
    private Material impactedPlanet;

    //TemperatureDelta is the radius of the orbit
    private float temperatureDelta;

    private float yBound = 0;

    
    // Start is called be e the first frame update
    void Start()
    {
        waterPlanet = Resources.Load("Water Planet", typeof(Material)) as Material;
        rockPlanet = Resources.Load("Default Rock", typeof(Material)) as Material;
        impactedPlanet = Resources.Load("Impact_Planet", typeof(Material)) as Material;
        StartCoroutine("setTemp");
    }

    // Update is called once per frame
    void Update()
    {
        if (lockPos)
        {
            if (transform.localPosition.y > yBound)
            {
                planetPosition.x = transform.localPosition.x;
                planetPosition.y = yBound;
                planetPosition.z = transform.localPosition.z;
                transform.localPosition = planetPosition;
            }
            else if (transform.localPosition.y < yBound)
            {
                planetPosition.x = transform.localPosition.x;
                planetPosition.y = yBound;
                planetPosition.z = transform.localPosition.z;
                transform.localPosition = planetPosition;
            }
        }

        setTemp();

        if (isWatered)
        {
            this.gameObject.GetComponent<Renderer>().material = waterPlanet;
            /*temperatureDelta = 800 / Vector3.Distance(star.transform.position, this.gameObject.transform.position);*/

        }
        else if (isImpacted)
        {
            this.gameObject.GetComponent<Renderer>().material = impactedPlanet;
            StopCoroutine("setTemp");
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = rockPlanet;
        }
    }


    public int getCountOfElement(Element e)
    {
        int retVal = 0;
        for(int i=0; i<elementsOnPlanet.Count; i++)
        {
            if (elementsOnPlanet[i] == e)
            {
                retVal++;
            }
        }
        return retVal;
    }


    public int getCountOfCompound(ChemicalCompound c)
    {
        int retVal = 0;
        for (int i = 0; i < compoundsOnPlanet.Count; i++)
        {
            if (compoundsOnPlanet[i] == c)
            {
                retVal++;
            }
        }
        return retVal;
    }


    public void spendElement(Element e)
    {
        if(elementsOnPlanet.Contains(e)) { elementsOnPlanet.Remove(e); }
        else { Debug.Log("Check Element Spending "+ e); }
    }


    //Getters and Setters

    /* 
     * Getting the list of elements
     */
    public List<Element> GetElements()
    {
        return elementsOnPlanet;
    }

    public void addCompoundToList(ChemicalCompound c)
    {
        Debug.Log(c + "Compount should add");
        compoundsOnPlanet.Add(c);
        Debug.Log(compoundsOnPlanet);
    }
    /*
     * Getting and Setting the temperature
     * 
     */
    public float getTemp()
    {
        return temperature;
    }

    public void setTemp()
    {
        temperatureDelta = Vector3.Distance(star.transform.position, this.gameObject.transform.position);
        //Only continue this calculation if the planet hasn't been impacted recently
        if (!isImpacted) { temperature = 1000 / temperatureDelta; }

    }

    public int getTempAsInt()
    {
        return (int)temperature;
    }


    public void setImpactedTrue(GameObject a)
    {
        
        Asteroid tempVal = a.GetComponent<Asteroid>();
        /*Debug.Log(a.name);
        Debug.Log(a.GetComponent<Asteroid>().getElementPresent());*/
        elementsOnPlanet.Add(tempVal.getElementPresent());
        
        /*for(int i=0; i<elementsOnPlanet.Count; i++)
        {
            Debug.Log(elementsOnPlanet[i]);
        }*/
        Destroy(a.gameObject);
        AudioSource.PlayClipAtPoint(_clip, transform.position);
        if(isImpacted) { return; }
        StartCoroutine(ImpactTempCalc());
    }

    public void setImpactedFalse()
    {
        StopCoroutine(ImpactTempCalc());
        isImpacted = false;

    }

    /*Coroutine to raise the temperature of the planet on impact, then slowly goes back to normal */
    IEnumerator ImpactTempCalc()
    {
        isImpacted = true;
        Debug.Log("Entered Corutine");
        int impactTemp = 1000;
        for (int i = impactTemp; i >= 0; i--)
        {
            temperature = impactTemp + (1000f / temperatureDelta);
            impactTemp--;
            yield return new WaitForSeconds(.2f);
        }
        //TESTING
        /*yield return new WaitForSeconds(.2f);*/
        setImpactedFalse();
    }

    /*public void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Handles.DrawWireDisc(star.transform.position, new Vector3(0, 1, 0), temperatureDelta, 2f);
    }*/


    /*
     * 
     * DrawOrbit() Will be called by XRGrabInteractable Hover Entered
     * 
     * 
     * EraseDrawOrbit() Will be called by XRGrabInteractable Hover Exited
     */
    public void DrawOrbit()
    {

    }

    public void EraseDrawOrbit()
    {

    }
}