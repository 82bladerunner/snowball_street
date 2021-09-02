using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void TaskOnClick()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }
}
