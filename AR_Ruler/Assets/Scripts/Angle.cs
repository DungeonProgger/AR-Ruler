using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Angle : MonoBehaviour
{
    [SerializeField] private GameObject Node;
    [SerializeField] private GameObject Edge;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject manager;
    [SerializeField] private GameObject ControlNode;
    [SerializeField] private GameObject Notes;

    List<GameObject> Nodes; 
    List<GameObject> Edges; 


    private void Start()
    {
        Nodes = manager.GetComponent<Manager>().Nodes;
        Edges = manager.GetComponent<Manager>().Edges;
    }

    public void AddNode()
    {
        foreach (var node in Nodes) { Destroy(node); }
        foreach (var edge in Edges) { Destroy(edge); }

        GameObject newNode1 = Instantiate(Node, transform);
        GameObject newNode2 = Instantiate(Node, transform);
        GameObject newNode3 = Instantiate(Node, transform);
        GameObject newEdge1 = Instantiate(Edge, transform);
        GameObject newEdge2 = Instantiate(Edge, transform);

        Nodes.Add(newNode1);
        Nodes.Add(newNode2);
        Nodes.Add(newNode3);
        Edges.Add(newEdge1);
        Edges.Add(newEdge2);
        manager.GetComponent<Manager>().flag = "Angle";

        newNode1.transform.position = Spawn.transform.position;
        newNode2.transform.position = new Vector3(Spawn.transform.position.x + 0.2f, Spawn.transform.position.y, Spawn.transform.position.z);
        newNode3.transform.position = new Vector3(Spawn.transform.position.x + 0.4f, Spawn.transform.position.y, Spawn.transform.position.z);

        newEdge1.GetComponent<GraphEdge>().StartNode = newNode1.GetComponent<GraphNode>();
        newEdge1.GetComponent<GraphEdge>().EndNode = newNode2.GetComponent<GraphNode>();
        newEdge2.GetComponent<GraphEdge>().StartNode = newNode2.GetComponent<GraphNode>();
        newEdge2.GetComponent<GraphEdge>().EndNode = newNode3.GetComponent<GraphNode>();

    }

    private void Update()
    {
        if (Nodes.Count != 0 && manager.GetComponent<Manager>().flag == "Angle")
        {
            ControlNode.gameObject.SetActive(false);
            float angle = Vector3.Angle(Nodes[Nodes.Count - 1].transform.position - Nodes[Nodes.Count - 2].transform.position, Nodes[Nodes.Count - 2].transform.position- Nodes[Nodes.Count - 3].transform.position);
            _text.text = "”гол:   " + (180.0f-angle)+ "\xB0";
            Notes.GetComponent<addNotes>().NoteText = _text.text;
        }
    }
}
