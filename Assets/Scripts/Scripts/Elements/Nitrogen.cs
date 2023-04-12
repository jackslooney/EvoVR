using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitrogen : Element
{
    public Nitrogen()
    {
        this.chemicalSymbol = "N";
        this.chemicalName = "Nitrogen";

        this.protons = 7;
        this.electrons = 7;

        this.description = "An element with 3 bonds, useful in many elemental compounds. Over 75% of Earth's atmosphere is made up of Nitrogen.";

        this.classification = group.Nonmetal;

        this.available_bonds = 3;
    }
}

