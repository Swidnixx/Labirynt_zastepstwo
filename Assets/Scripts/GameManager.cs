using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int time = 60;
    public int Points;
    public GameObject pausePanel;
    bool paused;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void Stopper()
    {
        time--;
        if(time < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        CancelInvoke();
        Debug.Log("Game Over");
    }

    public void AddTime(int timeToAdd)
    {
        time += timeToAdd;
        if(time < 1)
        {
            time = 1;
        }
    }

    public void FreezeTime(int time)
    {
        CancelInvoke();
        InvokeRepeating(nameof(Stopper), time, 1);
    }

    public int redKeys, greenKeys, goldKeys;
    public void AddKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                redKeys++;
                break;
            case KeyColor.Green:
                greenKeys++;
                break;
            case KeyColor.Gold:
                goldKeys++;
                break;
        }
    }
}
