using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLineBetweenPoints : MonoBehaviour
{
    public GameObject startPoint; // The starting point
    public GameObject endPoint; // The ending point

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Set the number of positions (points) for the line renderer
    }

    void Update()
    {
        if (startPoint != null && endPoint != null && lineRenderer != null)
        {
            // Define positions for the line using the provided points
            Vector3[] positions = new Vector3[2];
            positions[0] = startPoint.gameObject.GetComponent<Transform>().position;
            positions[1] = endPoint.gameObject.GetComponent<Transform>().position;

            // Assign positions to the LineRenderer
            lineRenderer.SetPositions(positions);
        }
    }
}
