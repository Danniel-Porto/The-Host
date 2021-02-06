using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip themeSong;

    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject settingsPanel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume") || !PlayerPrefs.HasKey("sense"))
        {
            PlayerPrefs.SetFloat("volume", 100f);
            PlayerPrefs.SetFloat("sense", 3f);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(themeSong, 1f * PlayerPrefs.GetFloat("volume")/100);
    }

    public void StartGame()
    {
        transform.Find("MainPanel").gameObject.SetActive(false);
        transform.Find("LorePanel").gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettingsPanel()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        settingsPanel.transform.Find("Dropdown").gameObject.GetComponent<Dropdown>().SetValueWithoutNotify(QualitySettings.GetQualityLevel());
    }

    public void CloseSettingsPanel()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void SetQuality(int i)
    {
        QualitySettings.SetQualityLevel(i);
        print(QualitySettings.GetQualityLevel());
    }

}
