using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

// public class Node {
//     public int value;
//     public Node left;
//     public Node right;

//     public Node(int value) {
//         this.value = value;
//         left = right = null;
//     }
// }

// public class Arvore : MonoBehaviour {
//     [SerializeField] public List<int> array = new List<int>();

//     private Node currentNode;

//     public Node BuildTree(List<int> array) {
//         if (array == null || array.Count == 0) return null;
//         return BuildTreeRecursive(array, 0);
//     }

//     private Node BuildTreeRecursive(List<int> array, int index) {
//         if (index >= array.Count) return null;

//         Node node = new Node(array[index]);

//         node.left = BuildTreeRecursive(array, 2 * index + 1);
//         node.right = BuildTreeRecursive(array, 2 * index + 2);

//         return node;
//     }

//     private TextControl _interface;

//     void Start() {
//         _interface = FindObjectOfType<TextControl>();

//         Node root = BuildTree(array);
//         currentNode = root; 
//         UpdateButtons(); 
//     }

//     private void UpdateButtons() {
//         Debug.Log("LEFT: " + currentNode.left.value + " || RIGHT: " + currentNode.right.value);

//         if (currentNode.left != null) {
//             _interface.SetLeftButtonTexts(currentNode.left.value);
//         } else {
//             _interface.SetLeftButtonTexts(0);
//         }

//         if (currentNode.right != null) {
//             _interface.SetRightButtonTexts(currentNode.right.value);
//         } else {
//             _interface.SetRightButtonTexts(0);
//         }
//     }

//     private void PrintTree(Node node) {
//         if (node == null) return;
//         PrintTree(node.left);
//         Debug.Log(node.value);
//         PrintTree(node.right);
//     }

//     public void ShowLeftNode() {
//         if (currentNode.left != null) {
//             currentNode = currentNode.left;
//             UpdateButtons();
//         }
//     }

//     public void ShowRightNode() {
//         if (currentNode.right != null) {
//             currentNode = currentNode.right;
//             UpdateButtons();
//         }
//     }
// }

public class TreeNode
{
    public string LocationName { get; set; } // Name or ID of the location
    public List<TreeNode> Children { get; set; } // List of child nodes
    public TreeNode Parent { get; set; } // Reference to the parent node

    public TreeNode(string locationName)
    {
        LocationName = locationName;
        Children = new List<TreeNode>();
        Parent = null;
    }

    // Add a child node
    public void AddChild(TreeNode child)
    {
        child.Parent = this; // Set the parent of the child
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

    // Example method to build a sample map
    public void BuildSampleMap()
    {
        TreeNode netlobo = new TreeNode("Caminho do Netlobo");
        TreeNode crypowym = new TreeNode("Labirinto do Crypowym");
        TreeNode firewallian = new TreeNode("Fortaleza do Firewallian");
        TreeNode patchpanda = new TreeNode("Caminho do Patchpanda");
        TreeNode syncrab = new TreeNode("Sincronizado do Syncrab");
        TreeNode quantumore = new TreeNode("Voo do Quantumore");
        // TreeNode win = new TreeNode("win");
        // TreeNode lose = new TreeNode("lose");

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

    // Move to a child node
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

    // Move to the parent node
    public bool MoveToParent()
    {
        if (_currentNode.Parent != null)
        {
            _currentNode = _currentNode.Parent;
            return true;
        }
        return false;
    }

    // Get the current location
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
}