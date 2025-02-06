using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    // Classe para armazenar o nome e o GameObject associado
    [System.Serializable]
    public class GameObjectItem
    {
        public string name; // Nome do GameObject
        public GameObject inGameObject; // O GameObject dentro do Canvas
    }

    // O Canvas que contém os GameObjects
    [SerializeField] private Canvas _canva;

    // Lista de todos os GameObjects dentro do Canvas
    public List<GameObjectItem> gameObjectList = new List<GameObjectItem>();

    // Guarda o GameObject atualmente ativo
    public GameObjectItem currentActiveGameObject;

    void Start()
    {
        if (_canva == null)
        {
            Debug.LogError("O Canvas não foi atribuído!");
            return;
        }

        // Popula a lista com todos os GameObjects filhos dentro do Canvas
        PopulateGameObjectList();

        if (gameObjectList.Count > 0)
        {
            // Ativa o primeiro GameObject como padrão
            currentActiveGameObject = gameObjectList[0];
            currentActiveGameObject.inGameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Nenhum GameObject foi encontrado dentro do Canvas.");
        }
    }
   
    // Função para popular a lista com todos os GameObjects dentro do Canvas
    private void PopulateGameObjectList()
    {
        foreach (Transform child in _canva.transform)
        {
            GameObjectItem newItem = new GameObjectItem
            {
                name = child.gameObject.name,
                inGameObject = child.gameObject
            };

            gameObjectList.Add(newItem);
        }
    }

    // Função para gerenciar a ativação e desativação dos GameObjects
    public void SetActiveScreen(string objectName)
    {
        // Procura o GameObject pelo nome
        GameObjectItem foundObject = gameObjectList.Find(item => item.name == objectName);
        GameObjectItem foundObjectGame = gameObjectList.Find(item => item.name == "Game"); // Declaração de foundObjectPauseScreen

        Debug.Log(objectName);

        if (foundObject != null)
        {
            // Desativa o GameObject atualmente ativo, a menos que seja "PauseScreen"
            if (currentActiveGameObject != null) 
            {
                currentActiveGameObject.inGameObject.SetActive(false);
                if (foundObjectGame != null)
                 {
                   foundObjectGame.inGameObject.SetActive(false);
                 }
                 else{
                    Debug.Log("Game não encontrado");
                 }
            }
            
            // Ativa o novo GameObject
            foundObject.inGameObject.SetActive(true);
            currentActiveGameObject = foundObject;
        }
        else
        {
            Debug.LogError($"GameObject com o nome {objectName} não foi encontrado dentro do Canvas.");
        }
    }
}