using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject[] bots;
    public int botsCount;
    public GameScore gameScore;

    private void Update()
    {
        // Keep track of bots that are still alive
        botsCount = 0;
        for(int i = 0; i < bots.Length; i++)
        {
            if(bots[i] != null)
            {
                botsCount++;
            }
        }

        // If there are no bots or player is dead, activate EndGame
        if(botsCount == 0 || player == null)
        {
            gameScore.EndGame();
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
