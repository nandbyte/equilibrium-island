using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject hoverlay;

    [SerializeField]
    private Material grassMaterial;

    [SerializeField]
    private Material hoverlayMaterial;

    [SerializeField]
    private GameObject building;

    private bool isHovered = false;
    private bool containsBuilding = false;
    private Vector3 buildingPosition;
    private GameObject previewBuilding;


    void Start()
    {
        buildingPosition = new Vector3(transform.position.x, 0.45f, transform.position.z);
    }

    private void OnMouseDown()
    {
        if (isHovered && !containsBuilding)
        {
            Instantiate(building, buildingPosition, Quaternion.identity);
            containsBuilding = true;
        }
    }

    private void OnMouseEnter()
    {
        isHovered = true;
        Debug.Log("Hello");
        hoverlay.GetComponent<Renderer>().material = hoverlayMaterial;
        if (!containsBuilding)
        {
            previewBuilding = Instantiate(building, buildingPosition, Quaternion.identity);
            previewBuilding.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }
    }

    private void OnMouseExit()
    {
        isHovered = false; Debug.Log("Bye");
        hoverlay.GetComponent<Renderer>().material = grassMaterial;
        Destroy(previewBuilding);
    }

}
