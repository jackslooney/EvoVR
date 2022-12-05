using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementManager : MonoBehaviour
{

    public PlayerPlanet playerPlanet;
    [SerializeField]
    private TextMeshProUGUI hydrogenCount;
    [SerializeField]
    private TextMeshProUGUI oxygenCount;
    [SerializeField]
    private TextMeshProUGUI nitrogenCount;
    [SerializeField]
    private TextMeshProUGUI chlorineCount;
    // Start is called before the first frame update
    void Start()
    {
        playerPlanet = GameObject.FindGameObjectWithTag("PlayerPlanet").GetComponent<PlayerPlanet>();
        
    }

    // Update is called once per frame
    void Update()
    {
        changeValues();
    }


    private void changeValues()
    {
        hydrogenCount.text = "H:" + playerPlanet.getCountOfElement(Element.element.Hydrogen).ToString();
        oxygenCount.text = "O:" + playerPlanet.getCountOfElement(Element.element.Oxygen).ToString();
        nitrogenCount.text = "N:" + playerPlanet.getCountOfElement(Element.element.Nitrogen).ToString();
        chlorineCount.text = "Cl:" + playerPlanet.getCountOfElement(Element.element.Chlorine).ToString();
    }



}
