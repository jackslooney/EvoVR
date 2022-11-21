using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
    public enum element { Hydrogen, Carbon, Oxygen, Nitrogen, Silicon, Chlorine, Sulfur, Iron, Magnesium, Calcium, Zinc, Potassium, Sodium };

    /*public List<elements> listOfElements;*/
    /*public elements element;*/

    private List<element> elements = new List<element>()
    { 
        element.Hydrogen, element.Carbon, element.Oxygen, element.Nitrogen, element.Silicon, element.Chlorine, element.Sulfur, element.Chlorine, element.Sulfur,
        element.Iron, element.Magnesium, element.Calcium, element.Zinc, element.Potassium, element.Sodium
    };
    public element elementSelected;

    /*public Element(element elementSelected)
    {
        this.elementSelected = elementSelected;
        setElementSelected();
    }

    public Element()
    {
        setElementSelected();
    }*/

    public void setElementSelected()
    {
        int i = Random.Range(0, elements.Count);
        elementSelected = elements[i];
    }

    public element getElementSelected()
    {
        return elementSelected;
    }
    public string getElementSelectedAsString()
    {
        return elementSelected.ToString();
    }
}
