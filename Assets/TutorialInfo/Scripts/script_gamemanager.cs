using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class script_gamemanager : MonoBehaviour
{
    public static int money;
    public static int money_multiplier;
    public static int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickToSelect();
    }

    void ClickToSelect()
    {
        
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawLine(ray.origin, ray.origin + ray.direction*250, Color.green, 10f);
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Did Hit");
                
                if (hit.collider.tag == "hitable")
                    hit.collider.gameObject.SendMessage("OnRaycastReceived");
                
            }
            else
            {
                Debug.Log("Did Not Hit");
            }

        }
    }
}
