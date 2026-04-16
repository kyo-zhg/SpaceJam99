using UnityEngine;
using UnityEngine.SceneManagement;

public class script_zone : MonoBehaviour
{
    private bool inonde = false;

    // argent gagne
    [SerializeField] int zoneMultiplier = 1;

    // pluviometre
    private float pluviometre = 0;
    [SerializeField] int pluviometreMultiplier = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script_gamemanager.money_multiplier += zoneMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        ZoneInonde();
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
        if (pluie)
        {
            // pluviometre += pluviometreMultiplier * Time.deltaTime;
        }
    }
}
