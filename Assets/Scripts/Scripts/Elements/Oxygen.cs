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

        this.description = "An essential element for many compounds, and also necessary for a number of lifeforms to exist.";

        this.classification = group.Nonmetal;

        this.available_bonds = 2;
    }
}
