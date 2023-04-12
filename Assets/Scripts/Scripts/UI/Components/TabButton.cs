using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class TabButton : MonoBehaviour
{
    public const int MAX_ARRAY_SIZE = 10;
    
    //reference to the button component of this button, so that other scripts can edit the visibility of this object
    public Button self;
    
    [Header("Children of this tab button")]
    //When this button is activated/deactivated, the children will be showm/hidden
    public ChildButton[] elementChildren = new ChildButton[MAX_ARRAY_SIZE];
    public ChildButtonCompound[] compoundChildren = new ChildButtonCompound[MAX_ARRAY_SIZE];
    [Header("Sibling Buttons")]
    //Sibling buttons
    public TabButton[] otherButtons = new TabButton[MAX_ARRAY_SIZE];

    [Header("Whether or not the button is Interactable")]
    public bool unlockValue = false;

    // Start is called before the first frame update
    void Start()
    {
        //FOR TESTING: if I want to start with all things active
        if(unlockValue) {
            self.interactable = true;
        }
        
        //this will normally run upon game launch
        if(!unlockValue) {
            self.interactable = false;
            //Set each child of this button to not visible
            HideContents();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(unlockValue == true) {
            this.SetInteractable(true);
        }
    }


    //ShowChildren() toggle off all other sibling button's children, and shows the current button's children
    public void ShowChildren() {
            foreach(TabButton b in otherButtons) {
                
                b.HideContents();
                Debug.Log(b.name);
                
            }
        if(elementChildren.Length > 0) {
            Debug.Log("ELEMENT CHILDREN CHECK");
            foreach(ChildButton c in elementChildren) {
                c.gameObject.SetActive(true);
            }
        }
        else if(compoundChildren.Length > 0) {
            foreach(ChildButtonCompound c in compoundChildren) {
                c.gameObject.SetActive(true);
            }
            
        }
    }

    //Hides the children of the this button
    public void HideContents() {
        if(elementChildren.Length > 0) {
            foreach(ChildButton c in elementChildren) {
                c.gameObject.SetActive(false);
            }
        } else if (compoundChildren.Length > 0) {
             foreach(ChildButtonCompound c in compoundChildren) {
                c.gameObject.SetActive(false);
            }
        }
        if(elementChildren.Length > 0) {
            elementChildren[0].infoContainer.hideInterface();
        }
        else if(compoundChildren.Length > 0) {
            compoundChildren[0].infoContainer.hideInterface();
        }
        
    }

    //Function to set whether or not this button can be pressed
    public void SetInteractable(bool t) {
        self.interactable = t;
    }


    //Only call this if the type of child pertains to Elements
    public void UnlockChildElement(Element e) {
        for(int i=0; i<elementChildren.Length; i++) {
            if(e.getSymbol() == elementChildren[i].ButtonText.text) {
                if(!elementChildren[i].self.interactable) {
                    elementChildren[i].self.interactable = true;
                }
            }
        }
    }

    //Only call this if the type of child pertains to ChemicalCompounds
    public void UnlockChildCompound(ChemicalCompound c) {
        for(int i=0; i<elementChildren.Length; i++) {
            if(!compoundChildren[i].self.interactable) {
                compoundChildren[i].self.interactable = true;
            }
        }
    }
}
