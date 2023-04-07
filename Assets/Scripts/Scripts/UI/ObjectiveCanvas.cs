using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveCanvas : MonoBehaviour
{
    public ProgressionManager progressionManager;

    public TextMeshProUGUI objective1;
    public TextMeshProUGUI objective2;
    public TextMeshProUGUI objective3;
    public TextMeshProUGUI objective4;
    public TextMeshProUGUI objective5;
    public TextMeshProUGUI objective6;
    // Update is called once per frame
    void Update()
    {
        if(progressionManager.goldylocksTemp) {
            objective1.color= Color.green;
        }
        else {
            objective1.color = Color.red;
        }
        if(progressionManager.oxygenObjective) {
            objective2.color= Color.green;
        }
        if(progressionManager.nitrogenObjective) {
            objective3.color= Color.green;
        }
        if(progressionManager.waterObjective) {
            objective4.color= Color.green;
        }
        if(progressionManager.carbonDioxObjective) {
            objective5.color= Color.green;
        }
        if(progressionManager.ozoneObjective) {
            objective6.color= Color.green;
        }
    }
}
