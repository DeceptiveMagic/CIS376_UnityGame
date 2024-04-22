using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BalloonSpawnerLogic : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(-4, 8, 52);
    public int balloonsLeftInRound;
    public float timer;
    public float timeIncrement;
    public string[] balloonTypes;
    public int numBalloonTypes;
    private bool levelComplete;
    private List<GameObject> spawnedBalloons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        balloonsLeftInRound = 0;
        timeIncrement = 0;
    }

    public bool IsRoundOver() {
        // If there are no balloons left to spawn and "is there anything in the list" returns false, the round is over.
        if (balloonsLeftInRound == 0 && !spawnedBalloons.Any()) {
            return true;
        }
        return false;
    }

    public void resetGame() {
        foreach (GameObject balloon in spawnedBalloons) {
            Destroy(balloon);
        }
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Purge any balloons that have been destroyed, meaning they are now null.
        spawnedBalloons.RemoveAll(item => item == null);
        // Increment the timer.
        timer += Time.deltaTime;
        // If we've reached the increment and there are balloons left to spawn, spawn them.
        if (timer >= timeIncrement && balloonsLeftInRound > 0 && !textManager.getGameWon()) {
            timer = 0;
            balloonsLeftInRound--;
            GameObject balloon = Instantiate(Resources.Load(balloonTypes[(int)Random.Range(0, numBalloonTypes)]) as GameObject);
            balloon.transform.position = spawnPosition;
            balloonController bController = balloon.GetComponent<balloonController>();
            for (int i = 0; i < 15; i++) {
                bController.points[i] = GameObject.Find("Point" + (i+1).ToString()).transform;
            }
            spawnedBalloons.Add(balloon);
        }
    }
}
