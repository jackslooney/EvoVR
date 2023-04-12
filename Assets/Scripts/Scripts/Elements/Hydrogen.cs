using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogen : Element
{
   public Hydrogen()
    {
        this.chemicalSymbol = "H";
        this.chemicalName = "Hydrogen";

        this.protons = 1;
        this.electrons = 1;

        this.description = "An element with only one bond, and an essential ingredient for life. It is used in many compounds, most important for us is water, which is necessary for the creation of many other compounds.";

        this.classification = group.Nonmetal;

        this.available_bonds = 1;
    }
}