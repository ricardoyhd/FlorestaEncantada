using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    private MapTree _mapTree;
    private MapNavigator _navigator;
    private TextControl _text;
    private ScreenControl _screen;
    private Dialogue _dialogue;

    string[] win = {"Fortaleza do Firewallian", "Voo do Quantumore"};
    string[] lose = {"Caminho do Patchpanda", "Sincronizado do Syncrab"};

    void Start() {
        _text = FindObjectOfType<TextControl>();
        _screen = FindObjectOfType<ScreenControl>();
        _dialogue = FindObjectOfType<Dialogue>();

        _mapTree = new MapTree("Início");
        _mapTree.BuildSampleMap();

        // Initialize the navigator
        _navigator = new MapNavigator(_mapTree.Root);

        // Example navigation
        Debug.Log($"Current Location: {_navigator.GetCurrentLocation()}");
        SetButtonTexts();
    }

    public void ReturnNode(){
        _navigator.MoveToParent();
        SetButtonTexts();
    }

    public void ReturnToBeginning(){
        while(_navigator.GetCurrentLocation() != "Início"){
            ReturnNode();
        }
    }

    public void MoveNode(int index){
        _navigator.MoveToChild(index);
        // _dialogue.AddLines(SetText());
        SetButtonTexts();
    }    

    public void CheckEnd(){
        if((_navigator.GetCurrentLocation() == "Fortaleza do Firewallian" ||
            _navigator.GetCurrentLocation() == "Voo do Quantumore") &&
            _dialogue.finishedDialogue == true){
            HandleEnd("Ganhou!!!");
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
    }

    public void SetButtonTexts(){
        _text.SetLeftButtonText(_navigator.GetLocationName(0));
        _text.SetRightButtonText(_navigator.GetLocationName(1));
    }

    public void SetText(){
        Debug.Log($"Current Location: {_navigator.GetCurrentLocation()}");
        if(_navigator.GetCurrentLocation() == "Caminho do Netlobo"){
            _dialogue.GameDialogue(new List<string> {"Ihaaaaa!", 
                                    "Você conseguiu rastrear o caminho e o nosso querido Netlobo iluminou o caminho com seus pelos de fibra ótica.",
                                    "Mas, agora, você precisa se decidir entre:"});
        }
        else if(_navigator.GetCurrentLocation() == "Labirinto do Crypowym"){
            _dialogue.GameDialogue(new List<string> {"Ho-ho-ho! Temos um Sherlock entre nós!", 
                                    "Parabéns, jovem gafanhoto! Você conseguiu resolver os enigmas do Labirinto do Cryptowywm!",
                                    "Mas, agora, você precisa se decidir entre:"});
        }
        else if(_navigator.GetCurrentLocation() == "Fortaleza do Firewallian"){
            _dialogue.GameDialogue(new List<string> {"OMG! Você provou perfeitamente as suas intenções e o dragão o levou para a SAÍDA da floresta!", 
                                    "UFA! Felizmente (ou infelizmente), você está livre das criaturas místicas computacionais.",
                                    "Até uma próxima partida, jovem gafanhoto!"});
        }
        else if(_navigator.GetCurrentLocation() == "Caminho do Patchpanda"){
            _dialogue.GameDialogue(new List<string> {"Pfff! O PatchPanda deixou a floresta vulnerável, com buracos de segurança, um grupo invasor fez você de prisioneiro!"});
        }
        else if(_navigator.GetCurrentLocation() == "Sincronizado do Syncrab"){
            _dialogue.GameDialogue(new List<string> {"Argh! Infelizmente, você não conseguiu sincronizar as informações, os fluxos de dados ficaram desorganizados, não obtendo uma alternativa de caminho para continuar o percurso."});
        }
        else if(_navigator.GetCurrentLocation() == "Voo do Quantumore"){
            _dialogue.GameDialogue(new List<string> {"Uau! Você é um gênio da probabilidade!", 
                                    "Conseguiu compreender a natureza probabilística de seus movimentos e resolver dilemas quânticos.",
                                    "Em forma de gratidão, o corvo mostrou um atalho para a saída!"});
        }
        else{
            _dialogue.GameDialogue(new List<string> {"AAAAAAAAAAAAA"});
        }
    }
}
