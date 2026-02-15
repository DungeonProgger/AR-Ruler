using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField] private GameObject Node;
    [SerializeField] private GameObject ControlNode;
    [SerializeField] private GameObject Edge;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject manager;
    [SerializeField] private GameObject Notes;

    private float time = 0f;


    List<GameObject> Nodes; 
    List<GameObject> Edges; 
    Rigidbody n_Rigidbody;

    private void Start()
    {
        Nodes = manager.GetComponent<Manager>().Nodes;
        Edges = manager.GetComponent<Manager>().Edges;
    }

    public void AddNode()
    {
        time = 0f;
        foreach (var node in Nodes) { Destroy(node); }
        foreach (var edge in Edges) { Destroy(edge); }

        GameObject newNode1 = Instantiate(Node, Vector3.zero, Quaternion.identity, transform);
        GameObject newNode2 = Instantiate(Node, Vector3.zero, Quaternion.identity, transform);
        GameObject newNode3 = Instantiate(Node, Vector3.zero, Quaternion.identity, transform);

        GameObject newEdge = Instantiate(Edge, Vector3.zero, Quaternion.identity, transform);

        transform.position = Spawn.transform.position;

        Nodes.Add(newNode1);
        Nodes.Add(newNode2);
        Nodes.Add(newNode3);
        Edges.Add(newEdge);
        manager.GetComponent<Manager>().flag = "Cylinder";

        newNode1.GetComponent<MeshRenderer>().enabled = false;
        newNode1.GetComponent<SphereCollider>().enabled = false;
        newNode1.transform.position = new Vector3(Spawn.transform.position.x , Spawn.transform.position.y - 0.2f, Spawn.transform.position.z);
        
        n_Rigidbody = newNode1.GetComponent<Rigidbody>();
        n_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;


        newNode2.transform.position = new Vector3(Spawn.transform.position.x + 0.2f, Spawn.transform.position.y-0.1f, Spawn.transform.position.z);
        n_Rigidbody = newNode2.GetComponent<Rigidbody>();
        n_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;

        newNode3.transform.position = new Vector3(Spawn.transform.position.x, Spawn.transform.position.y + 0.1f, Spawn.transform.position.z);
        n_Rigidbody = newNode3.GetComponent<Rigidbody>();
        n_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;


        ControlNode.transform.position = new Vector3(Spawn.transform.position.x , Spawn.transform.position.y + 0.1f, Spawn.transform.position.z);

        newEdge.GetComponent<CylinderEdge>().Node1 = newNode1.GetComponent<GraphNode>();
        newEdge.GetComponent<CylinderEdge>().Node2 = newNode2.GetComponent<GraphNode>();
        newEdge.GetComponent<CylinderEdge>().Node3 = newNode3.GetComponent<GraphNode>();


    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (Nodes.Count != 0 && time < 0 && manager.GetComponent<Manager>().flag == "Cylinder")
        {
            ControlNode.gameObject.SetActive(true);
            transform.position = new Vector3(ControlNode.transform.position.x, ControlNode.transform.position.y+0.1f, ControlNode.transform.position.z);
            float ScaleY = Vector3.Distance(Nodes[Nodes.Count - 3].transform.position, Nodes[Nodes.Count - 1].transform.position);
            float ScaleX = Vector3.Distance(Nodes[Nodes.Count - 3].transform.position, Nodes[Nodes.Count - 2].transform.position);
            float amount = Mathf.PI * ((ScaleX / 2) * (ScaleX / 2)) * ScaleY;
            _text.text = "Диаметр:   " + ScaleX + " м\n" +
                "Высота:   " + ScaleY + " м\n" +
                "Объём:   " + amount + " м3";
            Notes.GetComponent<addNotes>().NoteText = _text.text;
        }

    }
}
