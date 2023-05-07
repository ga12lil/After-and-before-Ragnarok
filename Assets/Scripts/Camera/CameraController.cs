using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 1.0f;
    [SerializeField] private float minZoom = 5.0f;
    [SerializeField] private float maxZoom = 10.0f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    /*private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            Zoom(zoomAmount);
        }
    }*/

    public void Zoom(float zoomAmount)
    {
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - zoomAmount, minZoom, maxZoom);
    }
}