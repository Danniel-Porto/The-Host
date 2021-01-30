using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip themeSong;

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

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
