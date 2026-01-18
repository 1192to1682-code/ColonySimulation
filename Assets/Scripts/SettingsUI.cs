using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    public Slider BGMSlider;

    public TextMeshProUGUI BGMSliderValue;

    public Slider seSlider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SetBGMValueText();
                
    }

    public void SetBGMValueText()
    {
        BGMSliderValue.text = $"{BGMSlider.value * 100}";
    }

}
