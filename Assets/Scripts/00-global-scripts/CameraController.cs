using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
   public float minZoom;
    public float maxZoom;

    public float camSize;

    private void Start()
    {
        GetComponent<Camera>().orthographicSize = camSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if (WorldEdges.edge != "world-edge-top")
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            if (WorldEdges.edge != "world-edge-bottom")
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (WorldEdges.edge != "world-edge-right")
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            if (WorldEdges.edge != "world-edge-left")
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        camSize += scroll * scrollSpeed;

        camSize = Mathf.Clamp(camSize, minZoom, maxZoom);

        GetComponent<Camera>().orthographicSize = camSize;

        Vector3 pos = transform.position;

        transform.position = pos;
    }

    public void DetectWorldEdges()
    {
        Debug.Log("out of bounds" + WorldEdges.edge);

    }
}
