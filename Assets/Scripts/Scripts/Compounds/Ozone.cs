using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ozone : ChemicalCompound
{
   
    public Ozone() {
        name = "Ozone";
        chemicalEq = "O3";
        ingredients = new List<Element>()
        {
            new Oxygen(),
            new Oxygen(),
            new Oxygen()
        };

        usage = "Ozone is a gaseous compound that helps absorb harmful UV light from the sun";
    }
}
