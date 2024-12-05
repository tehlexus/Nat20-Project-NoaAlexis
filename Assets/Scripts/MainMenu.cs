using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle invertYAxisToggle;

    private void Start()
    {
        invertYAxisToggle.isOn = GameManager.Instance.invertYAxis;

        invertYAxisToggle.onValueChanged.AddListener((value) =>
        {
            GameManager.Instance.invertYAxis = value;
        });
    }
	
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {

        //Application.Quit();
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                    Application.Quit();
        #endif

    }
}
