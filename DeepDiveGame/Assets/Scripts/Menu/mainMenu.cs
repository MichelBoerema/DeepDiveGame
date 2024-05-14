using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;

    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        mainPage.SetActive(true);
        settingsPage.SetActive(false);
    }

    public void ToggleSettingsButton()
    {
        bool state = mainPage.activeSelf;

        mainPage.SetActive(!state);
        settingsPage.SetActive(state);

        UpdateButtons();
    }

    public void UpdateButtons()
    {
        volumeSlider.value = Settings.volume * volumeSlider.maxValue;
    }

    //MAIN PAGE

    public void Main_StartGameButton()
    {
        print("Loading Game Scene");
        SceneManager.LoadScene("KevinGame", LoadSceneMode.Single);
    }
    public void Main_QuitButton()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    //SETTINGS PAGE

    public void Settings_VolumeSlider()
    {
        Settings.volume = volumeSlider.value / volumeSlider.maxValue;
        print($"volume changed to {volumeSlider.value / volumeSlider.maxValue}");
    }
}
