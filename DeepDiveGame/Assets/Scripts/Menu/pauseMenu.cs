using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPage;

    private void Start()
    {
        settingsPage.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        settingsPage.SetActive(!settingsPage.activeSelf);
    }

    //Pause Buttons

    public void Pause_ToMenuButton()
    {
        print("Loading Menu Scene");
        SceneManager.LoadScene("KevinMenu", LoadSceneMode.Single); //Verander naar beter ding
    }

    public void Pause_ExitButton()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
