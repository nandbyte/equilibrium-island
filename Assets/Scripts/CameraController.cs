using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cameraTransform;


    public float movementTime;

    public Vector3 zoomAmount;

    public Vector3 newPosition;



    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;




    void Start()
    {
        newPosition = transform.position;
        newZoom = cameraTransform.localPosition;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        ControlCamera();
    }

    void ControlCamera()
    {
        // Zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }


        // Position
        if (Input.GetMouseButtonDown(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }

        // Drag
        if (Input.GetMouseButton(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);
                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }

        newPosition = new Vector3(Mathf.Clamp(newPosition.x, -8f, 1f), 13, Mathf.Clamp(newPosition.z, -7f, 0f));
        newZoom = new Vector3(Mathf.Clamp(newZoom.x, -4f, 4f), Mathf.Clamp(newZoom.y, -8f, 8f), Mathf.Clamp(newZoom.z, -4f, 5f));

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }


}
