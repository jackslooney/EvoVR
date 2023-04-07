using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalCanvas : MonoBehaviour
{
    //instance variables
    [Header("Booleans for menu management:")]
    //bools for elements
    public bool unlockElements = false;
    public bool unlockHydrogen = false;
    public bool unlockOxygen = false;
    public bool unlockNitrogen = false;
    public bool unlockCarbon = false;

    //Bools for compounds
    public bool unlockCompounds = false;
    public bool unlockWater = false;
    public bool unlockMethane = false;
    public bool unlockCarbonDioxide = false;
    public bool unlockOzone = false;
    [Space]
    [Header("References to tab buttons")]
    public TabButton elementTab;
    public TabButton compoundTab;
    [Space]
    [Header("Reference to playerPlanet")]
    public PlayerPlanet playerPlanet;
    [Space]
    [Header("Reference to defined elements")]
    public ElementTracker tracker;
    public InfoContainer infoContainer;

    //Start is called when this object is initialized
    void Start() {
        if(!unlockElements) {
            elementTab.HideContents();
            compoundTab.HideContents();
            elementTab.SetInteractable(false);
            compoundTab.SetInteractable(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(playerPlanet.isImpacted) {
            StartCoroutine(ElementUnlockCheck());
        }
        if(playerPlanet.latestCompound != null) {
            StartCoroutine(CompoundUnlockCheck());
        }
    }


    IEnumerator ElementUnlockCheck() {
        if(!unlockElements) {
            Debug.Log("Element Tab unlock Value set True");
            elementTab.unlockValue = true;
            unlockElements = true;
        }
        
        if(playerPlanet.tempEl == tracker.getHydrogen() && !unlockHydrogen) {
            unlockHydrogen = true;
            elementTab.UnlockChildElement(playerPlanet.tempEl);
        }
        else if(playerPlanet.tempEl == tracker.getOxygen() && !unlockOxygen) {
            unlockOxygen = true;
            elementTab.UnlockChildElement(playerPlanet.tempEl);
        }
        else if(playerPlanet.tempEl == tracker.getNitrogen() && !unlockNitrogen) {
            unlockNitrogen = true;
            elementTab.UnlockChildElement(playerPlanet.tempEl);
        }
        else if(playerPlanet.tempEl == tracker.getCarbon() && !unlockCarbon) {
            unlockCarbon = true;
            elementTab.UnlockChildElement(playerPlanet.tempEl);
        }

        yield return new WaitForSeconds(.2f);
        EndUnlockCheck("element");
    }
    IEnumerator CompoundUnlockCheck() {
        if(!unlockCompounds) {
            compoundTab.unlockValue = true;
            unlockCompounds = true;
        }
        if(playerPlanet.latestCompound != null) {
            if(playerPlanet.latestCompound == tracker.getWater() && !unlockWater) {
                unlockWater = true;
                compoundTab.UnlockChildCompound(playerPlanet.latestCompound);
            }
        }
        yield return new WaitForSeconds(.2f);
        
        playerPlanet.setNullCompound();
        EndUnlockCheck("comp");

    }
    //Utility method for ending coroutines
    private void EndUnlockCheck(string s) {
        if(s == "element") {
            StopCoroutine(ElementUnlockCheck());
        } 
        else if(s == "comp") {
            StopCoroutine(CompoundUnlockCheck());
        }
    }


    //Getters and Setters
    public InfoContainer getContainer() {
        return infoContainer;
    }
}
