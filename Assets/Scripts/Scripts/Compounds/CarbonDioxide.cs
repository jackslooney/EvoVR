using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonDioxide : ChemicalCompound
{
    public CarbonDioxide() {
        name = "Carbon Dioxide";
        chemicalEq = "CO2";
        ingredients = new List<Element>()
        {
            new Carbon(),
            new Oxygen(),
            new Oxygen()
        };

        usage = "Carbon Dioxide is one of the primary carbon sources for life on Earth, and is a necessary ingredient in photosynthesis for plants";
        
    }
}
