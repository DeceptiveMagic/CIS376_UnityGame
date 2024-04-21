using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class textManager : MonoBehaviour
{
    TMP_Text livesLabel;
    TMP_Text moneyLabel;
    TMP_Text roundLabel;
    TMP_Text notPlayingLabel;
    TMP_Text nextUpgradeLabel;
    static int lives;
    static int money;
    static int currentCost;
    static int round;
    static bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        livesLabel = GameObject.Find("LivesText").GetComponent<TMP_Text>();
        moneyLabel = GameObject.Find("MoneyText").GetComponent<TMP_Text>();
        roundLabel = GameObject.Find("RoundText").GetComponent<TMP_Text>();
        nextUpgradeLabel = GameObject.Find("NextUpgradeText").GetComponent<TMP_Text>();
        notPlayingLabel = GameObject.Find("NotPlayingText").GetComponent<TMP_Text>();
        currentCost = 5;
        lives = 10;
        money = 0;
        round = 0;
        gameWon = false;
    }

    public static void decreaseLives(int value)
    {
        lives -= value;
    }

    public static int getMoney()
    {
        return money;
    }

    public static int getCurrentCost()
    {
        return currentCost;
    }

    public static int livesRemaining()
    {
        return lives;
    }

    public static void increaseMoney(int value)
    {
        money += value;
    }

    public static void buyUpgrade()
    {
        money -= currentCost;
        currentCost *= 2;
    }

    public static void increaseRound(int value)
    {
        round += value;
    }

    public static void setGameWon(bool isGameWon) {
        gameWon = isGameWon;
    }

    public static void resetGame() {
        currentCost = 5;
        lives = 10;
        money = 0;
        round = 0;
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        livesLabel.SetText("Lives: " + lives);
        moneyLabel.SetText("Money: " + money);
        roundLabel.SetText("Round: " + round);
        nextUpgradeLabel.SetText("Upgrade with RMB: $" + currentCost.ToString());

        if (gameWon) {
            round = 6;
            lives = 0;
            notPlayingLabel.SetText("You won! Press T to try again.");
        }
        else if (lives <= 0)
        {
            lives = 0;
            notPlayingLabel.SetText("Game over! Press T to try again.");
        }
        else
        {
            notPlayingLabel.SetText("+");
        }
    }
}
