using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int score = 0;
    public TextMeshProUGUI scoreText; // Reference to the Text component in the UI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
    }
    /*
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString(); // Update the score text in the UI
        Debug.Log("Score: " + score);
    }
    */
    public void Kill()
    {
        score += 10;
        scoreText.text = score.ToString(); // Update the score text in the UI
        Debug.Log("Score: " + score);
    }
}