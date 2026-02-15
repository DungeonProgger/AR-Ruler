using UnityEngine;

public class RadiusEdge : MonoBehaviour
{
    public GraphNode StartNode;
    public GraphNode EndNode;

    void FixedUpdate()
    {
        float distance = Vector3.Distance(StartNode.transform.position, EndNode.transform.position); 
        transform.localScale = new Vector3(distance, 0.0004242972f, distance);

        Vector3 middlePoint = (StartNode.transform.position + EndNode.transform.position) / 2; 
        transform.position = middlePoint;

        Vector3 rotationDirection = (EndNode.transform.position - StartNode.transform.position); 
        transform.rotation = Quaternion.LookRotation(rotationDirection);

    }

}
