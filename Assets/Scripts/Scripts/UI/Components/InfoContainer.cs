using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoContainer : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI symbol;


    public void updateElementInterface(Element e) {
        title.text = e.chemicalName;
        symbol.text = e.chemicalSymbol;
        description.text = e.description;
    }


    public void updateCompoundInterface(ChemicalCompound c) {
        title.text = c.name;
        symbol.text = c.getChemicalEq();
        description.text = c.getUsage();
    }

    public void hideInterface() {
        title.text = "";
        symbol.text = "";
        description.text = "";
    }
}
