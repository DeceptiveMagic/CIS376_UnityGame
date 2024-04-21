using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelIncrementLogic : MonoBehaviour
{
    const int NUM_LEVELS = 6;
    int[] numBalloonsPerLevel = {10, 20, 25, 30, 50, 100};
    float[] resetTimePerLevel = {1f, 1f, 0.5f, 0.5f, 0.5f, 0.3f};
    string[][] balloonTypesPerLevel = {
        new string[] {"RedBalloon"},
        new string[] {"RedBalloon", "BlueBalloon"},
        new string[] {"RedBalloon", "BlueBalloon", "GreenBalloon"},
        new string[] {"BlueBalloon", "GreenBalloon", "YellowBalloon"},
        new string[] {"BlueBalloon", "GreenBalloon", "YellowBalloon", "PinkBalloon"},
        new string[] {"PurpleBalloon", "GreenBalloon", "YellowBalloon", "PinkBalloon"}
    };
    int currentLevel;
    BalloonSpawnerLogic spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponent<BalloonSpawnerLogic>();
        currentLevel = 0;
    }

    public void resetGame() {
        currentLevel = 0;
        spawner.resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (NUM_LEVELS < currentLevel) {
            textManager.setGameWon(true);
        }
        else if (spawner.IsRoundOver() && textManager.livesRemaining() > 0) {
            spawner.numBalloonTypes = balloonTypesPerLevel[currentLevel].Length;
            spawner.balloonTypes = balloonTypesPerLevel[currentLevel];
            spawner.timeIncrement = resetTimePerLevel[currentLevel];
            spawner.balloonsLeftInRound = numBalloonsPerLevel[currentLevel];
            ++currentLevel;
            textManager.increaseRound(1);
        }
    }
}
