using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour
{
    public TextMeshProUGUI leftButton;
    public TextMeshProUGUI rightButton;
    public TextMeshProUGUI endText;

    public void SetLeftButtonText(string value){
        leftButton.text = value;
    }
    public void SetRightButtonText(string value){
        rightButton.text = value;
    }
    public void SetEndText(string value){
        endText.text = value;
    }
    // public void SetAllText(string category, string level, string error, string tip){
    //     SetCategory(category);
    //     SetLevel(level);
    //     SetError(error);
    //     SetTip(tip);
    // }
    // public void SetCategory(string category)
    // {
    //     categoryText.text = $"{category}";
    // }
    // public void SetLevel(string level)
    // {
    //     levelText.text = $"Level: {level}";
    // }
    // public void SetError(string error)
    // {
    //     errorText.text = $"Erros: {error}/3";
    // }
    // public void SetTip(string tip)
    // {
    //     tipText.text = $"{tip}";
    // }
    // public void SetEndText(string points)
    // {
    //     if(points == "5")
    //     {
    //         endText.text = $"Pontuação: {points}/5\n Você acertou todas!";
    //     }
    //     else
    //     {
    //         endText.text = $"Pontuação: {points}/5";
    //     }
    // }
    // public void TipCategoryText(bool state)
    // {
    //     tipTopText.enabled = state;
    //     tipText.enabled = state;
    // }
}
