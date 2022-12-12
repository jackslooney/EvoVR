using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : Element
{
    public Oxygen()
    {
        this.chemicalSymbol = "O";
        this.chemicalName = "Oxygen";

        this.protons = 8;
        this.electrons = 8;

        this.description = "An element with two bonds in the second electron layer";

        this.classification = group.Nonmetal;

        this.available_bonds = 2;
    }
}
