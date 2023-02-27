using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class ShowNumberRespawnInimigo : MonoBehaviour {
    public Slider sliderUI;
    public TextMeshProUGUI textSliderValue;

    void Start (){
        ShowSliderValue();
    }

    public void ShowSliderValue ()
    {

        string sliderMessage = "" + sliderUI.value;
        textSliderValue.text = sliderMessage;
    }
}
