using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    List<string> lines = new List<string>();
    List<string> startLines = new List<string>{"Olá, jovem gafanhoto! Seja muito bem-vindo a essa aventura super divertida pela Floresta Encantada: Jornada Digital. Durante o percurso, você irá encarar vários desafios.", 
                            "Mas atenção! Suas escolhas são muito importantes para que consiga sair dessa floresta! Vamos começar?",
                            "Então vamos lá! Você deve escolher entre:"};
    private float textSpeed = 0.02f;
    private ScreenControl _screen;
    private SoundManager _sound;
    public bool finishedDialogue = false;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;

        _screen = FindObjectOfType<ScreenControl>();
        _sound = FindObjectOfType<SoundManager>();
    }

    public void NextDialogue(){
        if(textComponent.text == lines[index]){
            NextLine();
            textSpeed = 0.02f;
        }
        else{
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    public void GameDialogue(List<string> lines){
        StopAllCoroutines();
        AddLines(lines);
        textComponent.text = string.Empty;
        index = 0;
        finishedDialogue = false;
        StartCoroutine(TypeLine());
    }

    public void StartDialogue(){
        GameDialogue(startLines);
    }

    public void AddLines(List<string> text){
        lines.Clear();
        for(int i = 0; i < text.Count; i++){
            lines.Add(text[i]);
        }
    }

    IEnumerator TypeLine(){
        int i = 0;
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            i++;
            if(i == 5){ 
                _sound.SpeechSound(); 
                i = 0;
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Count - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            finishedDialogue = true;
            _screen.SetActiveScreen("Decisão");
            index = 0;
        }
    }
}
