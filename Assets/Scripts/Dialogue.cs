using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    private float textSpeed = 0.05f;
    private ScreenControl _screen;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;

        _screen = FindObjectOfType<ScreenControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextDialogue(){
        if(textComponent.text == lines[index]){
            NextLine();
            textSpeed = 0.05f;
        }
        else{
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    public void StartDialogue(){
        StopAllCoroutines();
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index] .ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            _screen.SetActiveScreen("Jogo");
            // botões
        }
    }
}
