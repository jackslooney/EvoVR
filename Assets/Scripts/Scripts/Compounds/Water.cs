using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : ChemicalCompound
{  
   public Water()
    {
        name = "Water";
        chemicalEq = "H20";
        ingredients = new List<Element>()
        {
            new Hydrogen(),
            new Hydrogen(),
            new Oxygen()
        };

        usage = "Liquid water is one of the necessary components for getting new elements to mix together" +
            "\nAnd form more complex compounds!";
    }
}
