using UnityEngine;

public class CylinderEdge : MonoBehaviour
{
    public GraphNode Node1;
    public GraphNode Node2;
    public GraphNode Node3;

    void FixedUpdate()
    {
        float distanceXZ = Vector3.Distance(Node1.transform.position, Node2.transform.position); 
        float distanceY = Vector3.Distance(Node1.transform.position, Node3.transform.position); 
        transform.localScale = new Vector3(distanceXZ, distanceY/2, distanceXZ);
      
        transform.position = new Vector3(Node1.transform.position.x + (transform.localScale.x / 2), Node1.transform.position.y + (transform.localScale.y)+0.1f, Node1.transform.position.z);
    }

}

