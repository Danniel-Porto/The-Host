using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSetValues : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider senseSlider;
    [SerializeField] Text volumeValue;
    [SerializeField] Text senseValue;

    private void OnEnable()
    {
        volumeSlider.value = ((float)Mathf.Round(PlayerPrefs.GetFloat("volume") * 100f) / 100f);
        volumeValue.text = ((float)Mathf.Round(PlayerPrefs.GetFloat("volume") * 100f) / 100f).ToString();
        senseSlider.value = ((float)Mathf.Round(PlayerPrefs.GetFloat("sense") * 100f) / 100f);
        senseValue.text = ((float)Mathf.Round(PlayerPrefs.GetFloat("sense") * 100f) / 100f).ToString();
    }
}
