using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChildButton : MonoBehaviour
{
    public const int MAX_ARRAY_SIZE = 10;
    
    //reference to the button component of this button, so that other scripts can edit the visibility of this object
    public Button self;
    public TextMeshProUGUI ButtonText;
    public bool unlockValue = false;
    public Element focus;

    public JournalCanvas canvas;

    public InfoContainer infoContainer;
    public ElementTracker tracker;

    void Start() {
        if(!unlockValue) {
            self.interactable = false;
        }
        if(ButtonText.text == "H") {
            focus = tracker.getHydrogen();
        } else if(ButtonText.text == "N") {
            focus = tracker.getNitrogen();
        } else if(ButtonText.text == "O") {
            focus = tracker.getOxygen();
        } else if(ButtonText.text == "C") {
            focus = tracker.getCarbon();
        }
    }

    void Update() {
        if(focus == tracker.getHydrogen()) {
            if(canvas.unlockHydrogen) {
                self.interactable = true;
            }
        } else if(focus == tracker.getNitrogen()) {
            if(canvas.unlockNitrogen) {
                self.interactable = true;
            }
        } else if(focus == tracker.getOxygen()) {
            if(canvas.unlockOxygen) {
                self.interactable = true;
            }
        } else if(focus == tracker.getCarbon()) {
            if(canvas.unlockCarbon) {
                self.interactable = true;
            }
        }
    }


    public void showInterface() {
        infoContainer.updateElementInterface(focus);
    }
}
