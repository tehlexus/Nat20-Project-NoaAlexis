using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    public Toggle invertYAxisToggle;

    private void Start()
    {
        invertYAxisToggle.isOn = GameManager.Instance.invertYAxis;

        invertYAxisToggle.onValueChanged.AddListener((value) =>
        {
            GameManager.Instance.invertYAxis = value;
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }
}
