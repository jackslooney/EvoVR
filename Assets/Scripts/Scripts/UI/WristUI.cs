using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WristUI : MonoBehaviour
{

    PlayerPlanet playerPlanet;
    public GameObject ElementManagementCanvas;
    public GameObject JournalCanvas;
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
            asteroidAlert.fontSize = 1.3f;
           /* Debug.Log(asteroid.name);
            Debug.Log(asteroid.getElementPresent());*/
            asteroidAlert.text = "ASTEROID DETECTED!\n\nElement Present:\n" + asteroid.getElementPresentAsString();
            asteroid = null;
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
   


    public void toggleManagementCanvas()
    {
        if(ElementManagementCanvas.activeInHierarchy == false)
        {
            if(JournalCanvas.activeInHierarchy == true) {
                JournalCanvas.SetActive(false);
            }
            ElementManagementCanvas.SetActive(true);
        }
        else if(ElementManagementCanvas.activeInHierarchy == true)
        {
            ElementManagementCanvas.SetActive(false);
        }
    }
    

    public void toggleJournalCanvas() {
        if(JournalCanvas.activeInHierarchy == false)
        {
            if(ElementManagementCanvas.activeInHierarchy == true) {
                ElementManagementCanvas.SetActive(false);
            }
            JournalCanvas.SetActive(true);
        }
        else if(JournalCanvas.activeInHierarchy == true)
        {
            
            JournalCanvas.SetActive(false);
        }
    }
}
