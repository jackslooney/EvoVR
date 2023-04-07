using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ElementManagementCanvas : MonoBehaviour
{
    private PlayerPlanet p;

    private ElementTracker eTracker/*FindObjectOfType<ElementTracker>().GetComponent<ElementTracker>()*/;

    public TextMeshProUGUI hydrogenCount;
    public TextMeshProUGUI oxygenCount;
    public TextMeshProUGUI carbonCount;
    public TextMeshProUGUI nitrogenCount;

    public TextMeshProUGUI waterCount1;
    public TextMeshProUGUI waterCount2;
    public TextMeshProUGUI methaneCount1;
    public TextMeshProUGUI methaneCount2;
    public TextMeshProUGUI carbDioxCount1;
    public TextMeshProUGUI carbDioxCount2;
    
    public TextMeshProUGUI ozoneCount1;
    public TextMeshProUGUI ozoneCount2;


    public Button waterButton;
    public Button methaneButton;
    public Button carbDioxButton;
    public Button ozoneButton;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("PlayerPlanet").GetComponent<PlayerPlanet>();
        eTracker = FindObjectOfType<ElementTracker>().GetComponent<ElementTracker>();
        //StartCoroutine(checkForUnlock());
        //StartCoroutine(checkForUnlock());
    }
   
    void Update()
    {
        elementCountUpdate();
        compoundCountUpdate();
        /*if(waterUnlocked)
        {
            waterButton.interactable = true;
        } else
        {
            waterButton.interactable = false;
        }*/
    }

    public void elementCountUpdate()
    {
        hydrogenCount.text = "H:" + p.getCountOfElement(eTracker.getHydrogen());
        oxygenCount.text = "O:" + p.getCountOfElement(eTracker.getOxygen());
        carbonCount.text = "C:" + p.getCountOfElement(eTracker.getCarbon());
        nitrogenCount.text = "N:" + p.getCountOfElement(eTracker.getNitrogen());

        
    }

    public void compoundCountUpdate()
    {
        waterCount1.text = "Water: " + p.getCountOfCompound(eTracker.getWater());
        waterCount2.text = "H<sub>2</sub>O: " + p.getCountOfCompound(eTracker.getWater());
        methaneCount1.text = "Methane: " + p.getCountOfCompound(eTracker.GetMethane());
        methaneCount2.text = "OH<sub>4</sub>: " + p.getCountOfCompound(eTracker.GetMethane());
        carbDioxCount1.text = "Carbon Dioxide: " + p.getCountOfCompound(eTracker.GetCarbonDioxide());
        carbDioxCount2.text = "CO<sub>2</sub>: " + p.getCountOfCompound(eTracker.GetCarbonDioxide());
        ozoneCount1.text = "Ozone: " + p.getCountOfCompound(eTracker.GetOzone());
        ozoneCount2.text = "O<sub>3</sub>: " + p.getCountOfCompound(eTracker.GetOzone());
        
    }


    public void craftWater()
    {
        if(p.getCountOfElement(eTracker.getHydrogen()) >= 2 && p.getCountOfElement(eTracker.getOxygen()) >= 1)
        {
            
            p.spendElement(eTracker.getHydrogen());
            p.spendElement(eTracker.getHydrogen());
            p.spendElement(eTracker.getOxygen());
            p.addCompoundToList(eTracker.getWater());
        }
        else { Debug.Log("Not enough Elements"); }
    }

    public void craftMethane()
    {
        if(p.getCountOfElement(eTracker.getCarbon()) >= 1 && p.getCountOfElement(eTracker.getHydrogen()) >= 4) 
        {
            p.spendElement(eTracker.getOxygen());
            p.spendElement(eTracker.getHydrogen());
            p.spendElement(eTracker.getHydrogen());
            p.spendElement(eTracker.getHydrogen());
            p.spendElement(eTracker.getHydrogen());
            p.addCompoundToList(eTracker.GetMethane());
        }
        else { Debug.Log("Not enough Elements"); }
    }

    public void craftCarbonDioxide() 
    {
        if(p.getCountOfElement(eTracker.getCarbon()) >= 1 && p.getCountOfElement(eTracker.getOxygen()) >= 2) 
        {
            p.spendElement(eTracker.getCarbon());
            p.spendElement(eTracker.getOxygen());
            p.spendElement(eTracker.getOxygen());
            p.addCompoundToList(eTracker.GetCarbonDioxide());
        }
        else { Debug.Log("Not enough Elements"); }
    }

    public void craftOzone() {
        if(p.getCountOfElement(eTracker.getOxygen()) >= 3) 
        {
            p.spendElement(eTracker.getOxygen());
            p.spendElement(eTracker.getOxygen());
            p.spendElement(eTracker.getOxygen());
            p.addCompoundToList(eTracker.GetOzone());
        }
        else { Debug.Log("Not enough Elements"); }
    }


    /*private IEnumerator checkForUnlock()
    {
        if (p.getCountOfElement(eTracker.getHydrogen()) >= 2 && p.getCountOfElement(eTracker.getOxygen()) >= 1)
        {
            waterUnlocked = true;
            waterButton.interactable = true;
        }
        else { waterUnlocked = false; waterButton.interactable = false; }
        yield return new WaitForSeconds(.5f);
    }*/
}
