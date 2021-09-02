using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static WallScript Wall;
    public static Shooting shooting;
    public static GameObject WallFound;
    public GameObject GameOverScreen;
    public float scoreTimer;
    
    void Awake()
    {
        Wall = (WallScript)FindObjectOfType(typeof(WallScript));
        shooting = (Shooting)FindObjectOfType(typeof(Shooting));
        Time.timeScale = 1;
    }

    void Update()
    {


        if(WallFound)
        {
        scoreTimer += Time.deltaTime;
        }
        WallFound = GameObject.FindGameObjectWithTag("Wall");

        if(WallFound == null)
        {
            Time.timeScale = 0.25f;
            GameOverScreen.SetActive(true);
        }
    }
}
