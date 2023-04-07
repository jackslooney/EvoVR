using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methane : ChemicalCompound
{
    // Start is called before the first frame update
    public Methane()
    {
        name = "Methane";
        chemicalEq = "CH4";
        ingredients = new List<Element>()
        {
            new Carbon(),
            new Hydrogen(),
            new Hydrogen(),
            new Hydrogen(),
            new Hydrogen(),
        };

        usage = "Methane vents in the ocean were food sources for some of the first microbes on Earth!";
    }

    
}
