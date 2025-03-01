using UnityEngine;

public class Pointer : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public GameObject controller;
    public GameObject objetivo;

    private void Start()
    {

        lineRenderer = controller.GetComponent<LineRenderer>();

    }

    private void Update()
    {

        RaycastHit hit;

        controller.transform.Rotate(Vector3.up * 180f * Time.deltaTime);

        lineRenderer.SetPosition(0, controller.transform.position);

        Vector3 direction = controller.transform.forward * 3f;
        Vector3 posiciondos = controller.transform.position + direction;
        lineRenderer.SetPosition(1, posiciondos);

        Vector3 p1 = transform.position + transform.forward;
        Vector3 p2 = transform.position + transform.forward * 3;

        Vector3[] positions = new Vector3[2];

        positions[0] = p1;
        positions[1] = p2;

        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
        {

            Debug.DrawRay(direction, posiciondos * hit.distance, Color.yellow);

            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.black;
        }
        else
        {

            Debug.DrawRay(direction, posiciondos * 5f, Color.blue);

            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.green;
        }
    }
}