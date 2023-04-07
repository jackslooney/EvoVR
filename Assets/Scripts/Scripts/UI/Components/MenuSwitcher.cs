using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitcher : MonoBehaviour
{

    //Menus to change
    public GameObject menuToDisable;
    public GameObject menuToEnable;


    public void SwitchMenu() {
        menuToDisable.SetActive(false);
        menuToEnable.SetActive(true); 
    }
}
