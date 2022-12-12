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

    public TextMeshProUGUI waterCount;


    public Button waterButton;

    public bool waterUnlocked = true;
    private void Start()
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
        waterCount.text = "Water: " + p.getCountOfCompound(eTracker.getWater());
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
