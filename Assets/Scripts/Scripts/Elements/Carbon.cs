using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carbon : Element
{
    public Carbon()
    {
        this.chemicalSymbol = "C";
        this.chemicalName = "Carbon";

        this.protons = 6;
        this.electrons = 6;

        this.description = "An element with four bonds in the second electron layer";

        this.classification = group.Nonmetal;

        this.available_bonds = 4;
    }
}
