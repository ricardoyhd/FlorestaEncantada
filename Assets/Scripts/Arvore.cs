using UnityEngine;
using System.Collections.Generic;

public class TreeNode
{
    public string LocationName { get; set; } 
    public string LocationDescription { get; set; } 
    public List<TreeNode> Children { get; set; }
    public TreeNode Parent { get; set; }
    public int ImageIndex;

    public TreeNode(string locationName, string locationDescription = "empty", int index = 0)
    {
        LocationName = locationName;
        LocationDescription = locationDescription;
        Children = new List<TreeNode>();
        ImageIndex = index;
        Parent = null;
    }

    public void AddChild(TreeNode child)
    {
        child.Parent = this;
        Children.Add(child);
    }
}

public class MapTree
{
    public TreeNode Root { get; set; }

    public MapTree(string rootLocationName)
    {
        Root = new TreeNode(rootLocationName);
    }

    public void BuildSampleMap()
    {
        TreeNode netlobo = new TreeNode("Caminho do Netlobo", "Caminho do Netlobo\n\nO Netlobo ilumina o caminho com seus pelos de fibra ótica, ajudando a detectar falhas na rede. Nesse caminho, você rastreará o caminho, podendo ou não evitar perigos invisíveis.", 0);
        TreeNode crypowym = new TreeNode("Labirinto do Crypowym", "Labirinto do Crypowym\n\nO Cryptowyrm protege um labirinto de encriptação impenetrável. Nesse caminho, você deve resolverá enigmas de criptografia e superar seus desafios de segurança digital.", 1);
        TreeNode firewallian = new TreeNode("Fortaleza do Firewallian", "Fortaleza do Firewallian\n\nO Firewallian, uma criatura que combina dragão e muralha, bloqueia ameaças externas. Para avançar, você provará suas intenções e respeitará as camadas de segurança.", 2);
        TreeNode patchpanda = new TreeNode("Caminho do Patchpanda", "Caminho do Patchpanda\n\nO Patchpanda mantém a floresta livre de falhas, corrigindo buracos de segurança. Para seguir, você deverá ajudar a reparar os erros e manter a integridade do sistema.", 3);
        TreeNode syncrab = new TreeNode("Sincronizado do Syncrab", "Sincronizado do Syncrab\n\nO Syncrab garante que os dados fluam sem erros. Para continuar, você precisará ajudar a sincronizar informações entre diferentes partes da floresta, mantendo tudo em ordem.", 4);
        TreeNode quantumore = new TreeNode("Voo do Quantumore", "Voo do Quantumore\n\nO Quantumore, corvo quântico, está em múltiplos lugares ao mesmo tempo. Para avançar, compreenda a natureza probabilística de seus movimentos e resolver dilemas quânticos.", 5);

        Root.AddChild(netlobo);
        Root.AddChild(crypowym);
        netlobo.AddChild(firewallian);
        netlobo.AddChild(patchpanda);
        crypowym.AddChild(syncrab);
        crypowym.AddChild(quantumore);
    }
}

public class MapNavigator
{
    private TreeNode _currentNode;

    public MapNavigator(TreeNode startNode)
    {
        _currentNode = startNode;
    }

    public bool MoveToChild(int childIndex)
    {
        if (childIndex >= 0 && childIndex < _currentNode.Children.Count)
        {
            _currentNode = _currentNode.Children[childIndex];
            return true;
        }
        Debug.Log("Index inválido");
        return false;
    }

    public bool MoveToParent()
    {
        if (_currentNode.Parent != null)
        {
            _currentNode = _currentNode.Parent;
            return true;
        }
        return false;
    }

    public string GetCurrentLocation()
    {
        return _currentNode.LocationName;
    }
    public string GetLocationName(int index){
        if (index >= 0 && index < _currentNode.Children.Count)
        {
            return _currentNode.Children[index].LocationName;
        }
        return "Local inválido";
    }
    public string GetLocationDescription(int index){
        if (index >= 0 && index < _currentNode.Children.Count)
        {
            return _currentNode.Children[index].LocationDescription;
        }
        return "Local inválido";
    }
    public int GetImageIndex(int index){
        if (index >= 0 && index < _currentNode.Children.Count)
        {
            return _currentNode.Children[index].ImageIndex;
        }
        return 0;
    }
}