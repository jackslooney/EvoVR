using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ForceToggle : MonoBehaviour
{


    private XRController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<XRController>();
    }

   public void ToggleForce()
    {
        
    }
}
