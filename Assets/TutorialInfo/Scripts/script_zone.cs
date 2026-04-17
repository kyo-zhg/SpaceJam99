using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script_zone : MonoBehaviour
{
    private bool inonde = false;

    // argent gagne
    [SerializeField] int zoneMultiplier = 1;
    public float rainCostReference = 5f; // coût théorique d'une intervention

    // pluviometre
    public Slider rainSlider;
    // private float pluviometre = 0;
    // [SerializeField] int pluviometreMultiplier = 1;
    public float rainAccumulation = 0f;
    public float maxRain = 100f;

    public float rainSpeed = 2f;
    public bool isRaining = true;

    private float rainTimer = 0f;
    public float rainDuration = 10f;

    private float rainCooldownTimer = 0f;
    public float rainCooldownMin = 5f;
    public float rainCooldownMax = 15f;

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
        // Plus le joueur gagne d'argent,
        // plus la pluie a une chance d'arriver
        float rainChance = script_gamemanager.money_multiplier / rainCostReference;
        rainChance = Mathf.Clamp01(rainChance);

        // cooldown pour la pluie descend
        if (rainCooldownTimer > 0f)
        {
            rainCooldownTimer -= Time.deltaTime;
        }

        // Si pas de pluie, déclencher une pluie (et pas en cooldown)
        if (!isRaining && rainCooldownTimer <= 0f)
        {
            if (Random.value < rainChance * Time.deltaTime)
            {
                isRaining = true;
                // durée aléatoire de pluie
                rainTimer = Random.Range(5f, rainDuration);
            }
        }

        if (isRaining)
        {
            rainTimer -= Time.deltaTime;
            rainAccumulation += rainSpeed * Time.deltaTime;
            
            if (rainTimer <= 0f)
            {
                isRaining = false;

                // lancement du cooldown aléatoire
                rainCooldownTimer = Random.Range(rainCooldownMin, rainCooldownMax);
            }
        }
        else
        {
            rainAccumulation -= rainSpeed * Time.deltaTime * 0.5f; // descend plus lentement, faut voir selon les zones
        }

        rainAccumulation = Mathf.Clamp(rainAccumulation, 0f, maxRain);
        rainSlider.value = rainAccumulation / maxRain;

        if(rainAccumulation >= maxRain)
        {
            inonde = true;
        }
    }
}
