using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{
    TMP_Text livesLabel;
    TMP_Text moneyLabel;
    TMP_Text roundLabel;
    static int lives = 5;
    static int money = 300;
    static int round = 1;

    // Start is called before the first frame update
    void Start()
    {
        livesLabel = GameObject.Find("LivesText").GetComponent<TMP_Text>();
        moneyLabel = GameObject.Find("MoneyText").GetComponent<TMP_Text>();
        roundLabel = GameObject.Find("RoundText").GetComponent<TMP_Text>();
    }

    public static void decreaseLives(int value){
        lives -= value;
    }

    public static void increaseMoney(int value){
        money += value;
    }

    public static void increaseRound(int value){
        round += value;
    }

    // Update is called once per frame
    void Update()
    {
        livesLabel.SetText("Lives: " + lives);
        moneyLabel.SetText("Money: " + money);
        roundLabel.SetText("Round: " + round);
    }
}
