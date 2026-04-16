using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script_zone : MonoBehaviour
{
    private bool inonde = false;

    // argent gagne
    [SerializeField] int zoneMultiplier = 1;

    // pluviometre
    public Slider rainSlider;
    // private float pluviometre = 0;
    // [SerializeField] int pluviometreMultiplier = 1;
    public float rainAccumulation = 0f;
    public float maxRain = 100f;

    public float rainSpeed = 20f;
    public bool isRaining = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script_gamemanager.money_multiplier += zoneMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        ZoneInonde();
        Pluviometre();
    }

    // when player clicked on the zone
    public void OnRaycastReceived()
    {
        if (!inonde)
        {
            Debug.Log("message received");

            // open ui

        }
    }

    void ZoneInonde()
    {
        if (inonde)
        {
            script_gamemanager.money_multiplier -= zoneMultiplier; // zone dead
            if (script_gamemanager.money_multiplier == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }

    void Pluviometre()
    {
        bool pluie = Random.value < 0.5f;
        /*  if (pluie)
        {
            // pluviometre += pluviometreMultiplier * Time.deltaTime;
        }*/

        if (isRaining)
        {
            rainAccumulation += rainSpeed * Time.deltaTime;
        }
        else
        {
            rainAccumulation -= rainSpeed * Time.deltaTime;
        }

        // Clamp between 0 and maxRain
        rainAccumulation = Mathf.Clamp(rainAccumulation, 0f, maxRain);

        // Convert to 0–1 for the slider
        rainSlider.value = rainAccumulation / maxRain;

        if(rainAccumulation == maxRain)
        {
            inonde = true;
        }
    }
}
