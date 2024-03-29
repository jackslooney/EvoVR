using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTracker : MonoBehaviour
{
    /*
     * These Lists are to keep track of the specific elements on the planet
     * NOTE: THESE MAY BE UNNECESSARY
     */

    /*public List<Hydrogen> hydrogenList = new List<Hydrogen>();
    public List<Oxygen> oxygenList = new List<Oxygen>();
    public List<Nitrogen> nitrogenList = new List<Nitrogen>();
    public List<Carbon> carbonList = new List<Carbon>();*/

    /*
     * These variables keep track of what elements exist
     * 
     */
    public List<Element> listedElements = new List<Element>();
    public static Hydrogen hydrogen = new Hydrogen();
    public static Oxygen oxygen = new Oxygen();
    public static Carbon carbon = new Carbon();
    public static Nitrogen nitrogen = new Nitrogen();
    
    /*
     * These vars keep track of what compounds exist
     *
     */
    public List<ChemicalCompound> listedCompounds = new List<ChemicalCompound>();
    public static Water water = new Water();
    public static Methane methane = new Methane();
    public static CarbonDioxide carbonDioxide = new CarbonDioxide();
    public static Ozone ozone = new Ozone();
    void Awake()
    {
        listedElements = new()
        {
            hydrogen,
            oxygen,
            carbon,
            nitrogen
        };
        listedCompounds = new()
        {
            water,
            methane,
            carbonDioxide,
            ozone,
        };
    }
    
    


    public Element pickElement()
    {
        // Debug.Log(listedElements.Count);
        int index = Random.Range(0, listedElements.Count);
        return listedElements[index];
    }


    // Getters for referencing elements
    public Hydrogen getHydrogen()
    {
        return hydrogen;
    }

    public Oxygen getOxygen()
    {
        return oxygen;
    }

    public Nitrogen getNitrogen()
    {
        return nitrogen;
    }

    public Carbon getCarbon()
    {
        return carbon;
    }

    //Getters for referencing compounds
    public Water getWater()
    {
        return water;
    }

    public Methane GetMethane() {
        return methane;
    }

    public CarbonDioxide GetCarbonDioxide() {
        return carbonDioxide;
    }

    public Ozone GetOzone() {
        return ozone;
    }
}
