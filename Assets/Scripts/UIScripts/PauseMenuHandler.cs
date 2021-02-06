using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider senseSlider;
    [SerializeField] Text volumeValue;
    [SerializeField] Text senseValue;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioSource ambienceAudioSource;
    [SerializeField] GameObject fpsDisplay;

    [SerializeField] PlayerSettings ps;

    private void Start()
    {

    }

    private void Update()
    {
        PauseMenu();
        FpsCount();
    }

    void PauseMenu()
    {
        if (!pauseMenu.activeSelf & Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            pauseMenu.SetActive(false);
        }
    }

    void FpsCount()
    {
        int fps = (int) (1.0f / Time.smoothDeltaTime);
        fpsDisplay.GetComponent<Text>().text = (fps).ToString();
    }

    public void SetFpsDisplay(bool i)
    {
        fpsDisplay.SetActive(i);
    }

    public void ButtonConfirm()
    {
        ambienceAudioSource.volume = volumeSlider.value / 100;
        ps.playerVolume = volumeSlider.value/100;
        ps.playerSense = senseSlider.value;
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.SetFloat("sense", senseSlider.value);
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }
    
    public void ButtonCancel()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }

    public void ButtonQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateVolumeSlideValue()
    {
        volumeValue.text = ((float)Mathf.Round(volumeSlider.value * 100f) / 100f).ToString();
    }

    public void UpdateSenseSlideValue()
    {
        senseValue.text = ((float)Mathf.Round(senseSlider.value * 100f) / 100f).ToString();
    }
}