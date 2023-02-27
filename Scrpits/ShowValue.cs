using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour {
    public Slider sliderUI;
    public TextMeshProUGUI textSliderValue;

    void Start (){
        ShowSliderValue();
    }

    public void ShowSliderValue ()
    {
        int min = (int)(sliderUI.value / 60);
        int seg = (int)(sliderUI.value % 60);
        string sliderMessage = min + "m e "+ seg +"s";
        textSliderValue.text = sliderMessage;
    }
}
