using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChildButtonCompound : MonoBehaviour
{
    public const int MAX_ARRAY_SIZE = 10;
    
    //reference to the button component of this button, so that other scripts can edit the visibility of this object
    public Button self;
    public TextMeshProUGUI ButtonText;
    public bool unlockValue = false;
    public ChemicalCompound focus;

    public JournalCanvas canvas;

    public InfoContainer infoContainer;
    public ElementTracker tracker;

    void Start() {
        if(!unlockValue) {
            self.interactable = false;
        }
        if(ButtonText.text == "H<sub>2</sub>O") {
            focus = tracker.getWater();
        } 
        if(ButtonText.text == "OH<sub>4</sub>") {
            focus = tracker.GetMethane();
        } 
        if(ButtonText.text == "CO<sub>2</sub>") {
            focus = tracker.GetCarbonDioxide();
        } 
        if(ButtonText.text == "O<sub>3</sub>") {
            focus = tracker.GetOzone();
        } 
    }

    void Update() {
        if(focus == tracker.getWater()) {
            if(!canvas.unlockWater) {
                self.interactable = true;
            }
        } 
        else if(focus == tracker.GetMethane()) {
            if(!canvas.unlockMethane) {
                self.interactable = true;
            }
        }
        else if(focus == tracker.GetCarbonDioxide()) {
            if(!canvas.unlockCarbonDioxide) {
                self.interactable = true;
            }
        }
        else if(focus == tracker.GetOzone()) {
            if(!canvas.unlockOzone) {
                self.interactable = true;
            }
        }
    }


    public void showInterface() {
        infoContainer.updateCompoundInterface(focus);
    }
}
