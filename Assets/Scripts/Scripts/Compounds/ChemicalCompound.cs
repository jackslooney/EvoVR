using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public abstract class ChemicalCompound
{
    public string name;
    public string chemicalEq;
    public List<Element> ingredients;
    public string usage;

    /*public ChemicalCompound(List<Element> element)
    {
        this.name = CompoundCheck(element);
        ingredients = new List<Element>();
    }
*/

    /* private string CompoundCheck(List<Element> e)
     {
         string name;
         name = "This will reflect the name of the chemical compound";
         if (ingredients.Contains(Element.Hydrogen) && ingredients.Contains(Element.Oxygen))
         {
             name = "Water";
         }




         return name;
     }

     *//* Returns the ingredients of the compound *//*
     public List<element> getIngredients()
     {
         return ingredients;
     }*/

    /*public string getUses(string name)
    {
        string retVal = "";
        if(name == "Water")
        {
            retVal = "Water is great soup";
        }
        return retVal;
    }*/


    public ChemicalCompound()
    {

    }


    public string getName()
    {
        return name;
    }
    

    public string getChemicalEq()
    {
        return chemicalEq;
    }

    public List<Element> getIngredients()
    {
        return ingredients;
    }

    public string getUsage()
    {
        return usage;
    }

    public string getIngredientsToString()
    {
        string s = "";
        for(int i=0;i<ingredients.Count;i++)
        {
            s += ingredients[i].getChemicalName();
        }
        return s;
    }
}
