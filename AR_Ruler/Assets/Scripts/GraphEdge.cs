using UnityEngine;

public class GraphEdge : MonoBehaviour
{
    public GraphNode StartNode;
    public GraphNode EndNode;

    void FixedUpdate()
    {
        float distance = Vector3.Distance(StartNode.transform.position, EndNode.transform.position); 
        transform.localScale = new Vector3(0.005f, 0.005f, distance);        

        Vector3 middlePoint = (StartNode.transform.position + EndNode.transform.position) / 2; 
        transform.position = middlePoint;

        Vector3 rotationDirection = (EndNode.transform.position - StartNode.transform.position); 
        transform.rotation = Quaternion.LookRotation(rotationDirection);

    }

}
