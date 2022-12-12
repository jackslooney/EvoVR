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

        usage = "Water is one of the necessary components for getting new elements to mix together" +
            "\nYou will now be able to make more complex compounds";
    }
}
