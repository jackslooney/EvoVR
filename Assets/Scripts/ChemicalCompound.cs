using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChemicalCompound : Element
{

    public string name;

    public List<element> ingredients;

    public string use;

    public ChemicalCompound(List<element> element)
    {
        this.name = CompoundCheck(element);
        ingredients = new List<element>();
    }


    private string CompoundCheck(List<element> e)
    {
        string name;
        name = "This will reflect the name of the chemical compound";
        if (ingredients.Contains(element.Hydrogen) && ingredients.Contains(element.Oxygen))
        {
            name = "Water";
        }



        
        return name;
    }

    /* Returns the ingredients of the compound */
    public List<element> getIngredients()
    {
        return ingredients;
    }



    public string getUses(string name)
    {
        string retVal = "";
        if(name == "Water")
        {
            retVal = "Water is great soup";
        }

        return retVal;
    }
}
