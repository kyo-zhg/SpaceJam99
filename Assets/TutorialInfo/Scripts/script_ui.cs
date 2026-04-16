using UnityEngine;
using TMPro;


public class script_ui : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI moneyText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrintScoreMoney();
    }

    void PrintScoreMoney()
    {
        scoreText.text = ("Score: " + script_gamemanager.score.ToString("F0"));
        moneyText.text = ("Money: " + script_gamemanager.money.ToString());
    }
}
