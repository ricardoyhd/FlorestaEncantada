using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    private MapTree _mapTree;
    private MapNavigator _navigator;
    private TextControl _text;
    private ScreenControl _screen;
    private Dialogue _dialogue;
    private ImageControl _image;
    private SoundManager _sound;

    string[] win = {"Fortaleza do Firewallian", "Voo do Quantumore"};
    string[] lose = {"Caminho do Patchpanda", "Sincronizado do Syncrab"};

    void Start() {
        _text = FindObjectOfType<TextControl>();
        _screen = FindObjectOfType<ScreenControl>();
        _dialogue = FindObjectOfType<Dialogue>();
        _image = FindObjectOfType<ImageControl>();
        _sound = FindObjectOfType<SoundManager>();

        _mapTree = new MapTree("Início");
        _mapTree.BuildSampleMap();

        _navigator = new MapNavigator(_mapTree.Root);

        Debug.Log($"Current Location: {_navigator.GetCurrentLocation()}");
        SettersUI();
    }

    public void ReturnNode(){
        _navigator.MoveToParent();
        SettersUI();
    }

    public void ReturnToBeginning(){
        while(_navigator.GetCurrentLocation() != "Início"){
            ReturnNode();
        }
    }

    public void MoveNode(int index){
        _navigator.MoveToChild(index);
        SettersUI();
    }    

    public void CheckEnd(){
        if((_navigator.GetCurrentLocation() == "Fortaleza do Firewallian" ||
            _navigator.GetCurrentLocation() == "Voo do Quantumore") &&
            _dialogue.finishedDialogue == true){
            HandleEnd("Parabéns!");
        }
        else if((_navigator.GetCurrentLocation() == "Caminho do Patchpanda" ||
            _navigator.GetCurrentLocation() == "Sincronizado do Syncrab") &&
            _dialogue.finishedDialogue == true){
            HandleEnd("Perdeu...");
        }
    }
    public void HandleEnd(string text){
        _screen.SetActiveScreen("Fim");
        _text.SetEndText(text);
        if(text == "Parábens!"){ 
            _image.SetEndingBackgroundImage(0); 
            _sound.WinSound();
        }
        else{ 
            _image.SetEndingBackgroundImage(1); 
            _sound.LoseSound();
        }
        
    }

    public void SettersUI(){
        SetButtonTexts();
        SetInfoBoxTexts();
        SetAnimalImages();
    }
    public void SetButtonTexts(){
        _text.SetLeftButtonText(_navigator.GetLocationName(0));
        _text.SetRightButtonText(_navigator.GetLocationName(1));
    }

    public void SetInfoBoxTexts(){
        _text.SetLeftInfoBox(_navigator.GetLocationDescription(0));
        _text.SetRightInfoBox(_navigator.GetLocationDescription(1));    
    }
    public void SetAnimalImages(){
        _image.SetLeftAnimalImage(_navigator.GetImageIndex(0));
        _image.SetRightAnimalImage(_navigator.GetImageIndex(1));    
    }

    public void SetText()
    {
        string currentLocation = _navigator.GetCurrentLocation();
        
        var dialogues = new Dictionary<string, List<string>>()
        {
            {
                "Caminho do Netlobo", new List<string>
                {
                    "Ihaaaaa!", 
                    "Você conseguiu rastrear o caminho e o nosso querido Netlobo iluminou o caminho com seus pelos de fibra ótica.",
                    "Mas, agora, você precisa se decidir entre:"
                }
            },
            {
                "Labirinto do Crypowym", new List<string>
                {
                    "Ho-ho-ho! Temos um Sherlock entre nós!", 
                    "Parabéns, jovem gafanhoto! Você conseguiu resolver os enigmas do Labirinto do Cryptowywm!",
                    "Mas, agora, você precisa se decidir entre:"
                }
            },
            {
                "Fortaleza do Firewallian", new List<string>
                {
                    "OMG! Você provou perfeitamente as suas intenções e o dragão o levou para a SAÍDA da floresta!", 
                    "UFA! Felizmente (ou infelizmente), você está livre das criaturas místicas computacionais.",
                    "Até uma próxima partida, jovem gafanhoto!"
                }
            },
            {
                "Caminho do Patchpanda", new List<string>
                {
                    "Pfff! O PatchPanda deixou a floresta vulnerável, com buracos de segurança, um grupo invasor fez você de prisioneiro!"
                }
            },
            {
                "Sincronizado do Syncrab", new List<string>
                {
                    "Argh! Infelizmente, você não conseguiu sincronizar as informações, os fluxos de dados ficaram desorganizados, não obtendo uma alternativa de caminho para continuar o percurso."
                }
            },
            {
                "Voo do Quantumore", new List<string>
                {
                    "Uau! Você é um gênio da probabilidade!", 
                    "Conseguiu compreender a natureza probabilística de seus movimentos e resolver dilemas quânticos.",
                    "Em forma de gratidão, o corvo mostrou um atalho para a saída!"
                }
            }
        };

        if (dialogues.ContainsKey(currentLocation)){ _dialogue.GameDialogue(dialogues[currentLocation]); }
        else{ _dialogue.GameDialogue(new List<string> { "else" }); }
    }

}
