using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Radius : MonoBehaviour
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
        GameObject newEdge = Instantiate(Edge, transform);

        Nodes.Add(newNode1);
        Nodes.Add(newNode2);
        Edges.Add(newEdge);
        manager.GetComponent<Manager>().flag = "Radius";

        newNode1.transform.position = Spawn.transform.position;
        newNode2.transform.position = new Vector3(Spawn.transform.position.x + 0.2f, Spawn.transform.position.y, Spawn.transform.position.z);

        newEdge.GetComponent<RadiusEdge>().StartNode = newNode1.GetComponent<GraphNode>();
        newEdge.GetComponent<RadiusEdge>().EndNode = newNode2.GetComponent<GraphNode>();

    }

    private void Update()
    {
        if (Nodes.Count != 0 && manager.GetComponent<Manager>().flag == "Radius")
        {
            ControlNode.gameObject.SetActive(false);
            float distance = Vector3.Distance(Nodes[Nodes.Count - 2].transform.position, Nodes[Nodes.Count - 1].transform.position);
            _text.text = "Диаметр:   " + distance + " м\n" +
                "Диаметр:   " + distance/2 + " м";
            Notes.GetComponent<addNotes>().NoteText = _text.text;
        }
       
    }
}
