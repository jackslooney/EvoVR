using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WristUI : MonoBehaviour
{

    PlayerPlanet playerPlanet;

    [SerializeField]
    private TextMeshProUGUI temperatureDisplay;
    [SerializeField]
    private TextMeshProUGUI asteroidAlert;
    [Space]
    [Header("Asteroid Track")]
    [SerializeField]
    private Asteroid asteroid;
    // Start is called before the first frame update
    void Start()
    {
        playerPlanet = GameObject.FindGameObjectWithTag("PlayerPlanet").GetComponent<PlayerPlanet>();
    }

    // Update is called once per frame
    void Update()
    {
        temperatureDisplay.text = "Temperature: " + playerPlanet.getTempAsInt().ToString();

        if(GameObject.FindGameObjectWithTag("Asteroid"))
        {
            asteroid = GameObject.FindGameObjectWithTag("Asteroid").GetComponent<Asteroid>();
            /*asteroidAlert.fontSize = */
            asteroidAlert.text = "ASTEROID DETECTED!\n\nElement Present:\n" + asteroid.getElementPresentAsString();
        } else
        {
            asteroid = null;
            asteroidAlert.text = "";
        }

        
    }


    public void asteroidPresent()
    {
        //isAsteroid = true;
    }
   
}
