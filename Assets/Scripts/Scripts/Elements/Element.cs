using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element
{
    /*public enum elements { Hydrogen, Carbon, Oxygen, Nitrogen, Silicon, Chlorine, Sulfur, Iron, Magnesium, Calcium, Zinc, Potassium, Sodium };

    public List<elements> listOfElements;
    public elements element;

    private List<element> elements = new List<element>()
    {
        element.Hydrogen, element.Carbon, element.Oxygen, element.Nitrogen, element.Silicon, element.Chlorine, element.Sulfur, element.Chlorine, element.Sulfur,
        element.Iron, element.Magnesium, element.Calcium, element.Zinc, element.Potassium, element.Sodium
    };
    public element elementSelected;

    public Element(element elementSelected)
    {
        this.elementSelected = elementSelected;
        setElementSelected();
    }

    public Element()
    {
        setElementSelected();
    }

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
    }*/

    public enum group { Nonmetal, Metaloid, Alkali_Metal, Alkaline_Earth_Metal, Transition_Metal }


    public string chemicalSymbol, chemicalName, description;
    public int protons, electrons, available_bonds;
    public group classification;
    public Element()
    {
      
    }


    public string getSymbol()
    {
        return chemicalSymbol;
    }
    public string getChemicalName()
    {
        return chemicalName;
    }
    public string getDescription()
    {
        return description;
    }

    public int getProtons()
    {
        return protons;
    }
    public int getElectrons()
    {
        return electrons;
    }

}