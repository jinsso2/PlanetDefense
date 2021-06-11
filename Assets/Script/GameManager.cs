using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int moonIndex;
    public float time;
    public float timeRecord;

    public GameObject[] Moons;
    public GameObject gameOverText;
    public GameObject timer, healthUI;
    public Text timeText;
    public Text timeRecorded;

    void Start()
    {
        moonIndex = 0;
        time = 0;
        timeRecord = 0;
        gameOverText.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        timeRecord += Time.deltaTime;
        timeText.text = "Time : " + string.Format("{0:N1}", time);
        timeRecorded.text = "버틴 시간 : " + string.Format("{0:N1}", timeRecord) + "초";
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        timer.SetActive(false);
        healthUI.SetActive(false);
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0; 
    }

    public void NextMoon()
    {
        if (moonIndex < Moons.Length - 1) 
        {
            Moons[moonIndex].SetActive(false);
            moonIndex++;
            Moons[moonIndex].SetActive(true);
        }
    }
}
