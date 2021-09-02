using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    private float score;
    private int flooredScore;
    public GameManager GameManager;
    void Start()
    {
        score = GameManager.scoreTimer;
        flooredScore = Mathf.FloorToInt(score);
    }

    void Update()
    {
        scoreText.text = flooredScore.ToString() + " seconds";
    }
}
