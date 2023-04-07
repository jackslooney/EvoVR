using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public PlayerPlanet playerPlanet;
    
    //For tracking if the planet is in the correct temperature range for liquid water
    public bool goldylocksTemp = false;

    //For tracking if enough of a given required element is on the planet
    public bool oxygenObjective = false;
    public bool nitrogenObjective = false;
    public bool waterObjective = false;
    public bool methaneObjective = false;
    public bool carbonDioxObjective = false;
    public bool ozoneObjective = false;
    

    //get references to the elementTracker
    public ElementTracker tracker;

    // Update is called once per frame
    void Update()
    {
        if(playerPlanet.temperature > 0 && playerPlanet.temperature < 100) {
            goldylocksTemp = true;
        }
        if(playerPlanet.getCountOfCompound(tracker.getWater()) >= 4) {
            waterObjective = true;
        }
        if(playerPlanet.getCountOfCompound(tracker.GetCarbonDioxide()) >= 3) {
            waterObjective = true;
        }
        if(playerPlanet.getCountOfCompound(tracker.GetOzone()) >= 2) {
            waterObjective = true;
        }
        // if(playerPlanet.getCountOfCompound(tracker.getMethane()) >= 4) {
        //     methaneObjective = true;
        // }
        if(playerPlanet.getCountOfElement(tracker.getOxygen()) >= 3) {
            oxygenObjective = true;
        }
        if(playerPlanet.getCountOfElement(tracker.getNitrogen()) >= 8) {
            nitrogenObjective = true;
        }
       
    }
}
