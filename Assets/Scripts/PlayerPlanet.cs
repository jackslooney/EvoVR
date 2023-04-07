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
    public float temperature;

    [Header("Lock the Y Axis of this planet")]
    public bool lockPos = true;
    // [Header("Add water to this planet")]
    // [SerializeField]
    // private bool isWatered;
    // [Header("Add Humidity to the this planet")]
    // [SerializeField]
    // private bool isHumid;

    [Header("If the planet has been impacted recently")]
    [SerializeField]
    public bool isImpacted;
    
    [Header("All of the Elements on the Planet")]
    [SerializeField]
    public List<Element> elementsOnPlanet = new List<Element>();
    [Header("All of the Compounds on the Planet")]
    [SerializeField]
    public List<ChemicalCompound> compoundsOnPlanet = new List<ChemicalCompound>();
    

    // For Journal Management
    public Element tempEl;

    public ChemicalCompound latestCompound;

    [Header("Planet States")]
    public GameObject waterPlanet;
    public GameObject greenPlanet;
    public GameObject impactedPlanet;
    /* All Private Variables */
    //Water Material
    // private Material rockPlanet;
    // private Material impactedPlanet;

    //TemperatureDelta is the radius of the orbit
    private float temperatureDelta;

    private float yBound = 0;

    [Space]
    [Header("Tracker for reference to element and compound definitions")]
    public ElementTracker tracker;
    
    // Start is called before the first frame update
    void Start()
    {
        // //start the temperature tracking
        // StartCoroutine("setTemp");
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

        if (getCountOfCompound(tracker.getWater()) >= 1)
        {
            waterPlanet.SetActive(true);
        } 
        // if(getCountOfCompound(tracker.getWater()) > 4) {
        //     isHumid = true;
        // }
        if(getCountOfElement(tracker.getNitrogen()) > 3 && getCountOfCompound(tracker.GetOzone()) > 4) {
            greenPlanet.SetActive(true);
        }
        if (isImpacted)
        {
            impactedPlanet.SetActive(true);
            // StopCoroutine("setTemp");
        }
        
    }



    //Element Management
    public void spendElement(Element e)
    {
        if(elementsOnPlanet.Contains(e)) { elementsOnPlanet.Remove(e); }
        else { Debug.Log("Check Element Spending " + e); }
    }


    //Getters and Setters
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

    /* 
     * Getting the list of elements
     */
    public List<Element> GetElements()
    {
        return elementsOnPlanet;
    }


    // Compound Management
    public void addCompoundToList(ChemicalCompound c)
    {
        Debug.Log(c + "Compound should add");
        compoundsOnPlanet.Add(c);
        latestCompound = c;
        Debug.Log(compoundsOnPlanet);
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
        if (!isImpacted) { temperature = 1000 / temperatureDelta; }

    }

    public int getTempAsInt()
    {
        return (int)temperature;
    }


    /* Handler for Asteroid Impacts
     * a -- Asteroid
     * Returns -- void
     */
    public void setImpactedTrue(GameObject a)
    {
        
        Asteroid tempVal = a.GetComponent<Asteroid>();
        /*Debug.Log(a.name);
        Debug.Log(a.GetComponent<Asteroid>().getElementPresent());*/
        elementsOnPlanet.Add(tempVal.getElementPresent());
        
        //for checking journal entries
        tempEl = tempVal.getElementPresent();
        /*for(int i=0; i<elementsOnPlanet.Count; i++)
        {
            Debug.Log(elementsOnPlanet[i]);
        }*/
        Destroy(a.gameObject);
        AudioSource.PlayClipAtPoint(_clip, transform.position);
        if(isImpacted) { return; }
        StartCoroutine(ImpactTempCalc());
    }

    /**
     * Stops the CoRoutine that runs on impact
      * 
     */
    public void setImpactedFalse()
    {
        StopCoroutine(ImpactTempCalc());
        isImpacted = false;
        impactedPlanet.SetActive(false);
        StartCoroutine("setTemp");

    }

    /*Coroutine to raise the temperature of the planet on impact, then slowly goes back to normal */
    IEnumerator ImpactTempCalc()
    {
        isImpacted = true;
        Debug.Log(isImpacted);
        int impactTemp = 200;
        for (int i = impactTemp; i >= 0; i--)
        {
            temperature = impactTemp + (1000f / temperatureDelta);
            impactTemp--;
            yield return new WaitForSeconds(.1f);
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

    public void setNullCompound() {
        latestCompound = null;
    }
}