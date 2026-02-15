using UnityEngine;

public class CubeEdge : MonoBehaviour
{
    public GraphNode Node1;
    public GraphNode Node2;
    public GraphNode Node3;
    public GraphNode Node4;

    void FixedUpdate()
    {
       
        float distanceX = Vector3.Distance(Node1.transform.position, Node2.transform.position); 
        float distanceZ = Vector3.Distance(Node1.transform.position, Node3.transform.position); 
        float distanceY = Vector3.Distance(Node1.transform.position, Node4.transform.position); 
        transform.localScale = new Vector3(distanceX, distanceY, distanceZ);
      
        transform.position = new Vector3(Node1.transform.position.x+(transform.localScale.x/2), Node1.transform.position.y + (transform.localScale.y / 2), Node1.transform.position.z + (transform.localScale.z / 2));
    }

}

