using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    private MapTree _mapTree;
    private MapNavigator _navigator;
    private TextControl _interface;
    private ScreenControl _screen;

    string[] win = {"Fortaleza do Firewallian", "Voo do Quantumore"};
    string[] lose = {"Caminho do Patchpanda", "Sincronizado do Syncrab"};

    void Start() {
        _interface = FindObjectOfType<TextControl>();
        _screen = FindObjectOfType<ScreenControl>();

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

        if(CheckEnd(_navigator.GetCurrentLocation())) Debug.Log("fim");
        else SetButtonTexts();
    }    

    public bool CheckEnd(string currentLocaction){
        if(currentLocaction == "Fortaleza do Firewallian" || currentLocaction == "Voo do Quantumore"){
            HandleEnd("Ganhou!!!");
            return true;
        }
        else if(currentLocaction == "Caminho do Patchpanda" || currentLocaction == "Sincronizado do Syncrab"){
            HandleEnd("Perdeu...");
            return true;
        }
        return false;
    }
    public void HandleEnd(string text){
        _screen.SetActiveScreen("Fim");
        _interface.SetEndText(text);
    }

    public void SetButtonTexts(){
        _interface.SetLeftButtonText(_navigator.GetLocationName(0));
        _interface.SetRightButtonText(_navigator.GetLocationName(1));
    }
}
