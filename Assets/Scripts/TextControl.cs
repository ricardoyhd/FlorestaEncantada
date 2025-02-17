using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour
{
    public TextMeshProUGUI leftButton;
    public TextMeshProUGUI rightButton;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI leftInfoBox;
    public TextMeshProUGUI rightInfoBox;

    public void SetLeftButtonText(string text){
        leftButton.text = text;
    }
    public void SetRightButtonText(string text){
        rightButton.text = text;
    }
    public void SetEndText(string text){
        endText.text = text;
    }
     public void SetLeftInfoBox(string text){
        leftInfoBox.text = text;
    }
    public void SetRightInfoBox(string text){
        rightInfoBox.text = text;
    }
}
