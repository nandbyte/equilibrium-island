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

    public Cell cell;

    private bool isHovered = false;
    private bool containsBuilding = false;
    private Vector3 buildingPosition;
    private GameObject previewBuilding;




    void Start()
    {
        buildingPosition = new Vector3(transform.position.x, 0.35f, transform.position.z);
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
        hoverlay.GetComponent<Renderer>().material = hoverlayMaterial;
        if (!containsBuilding)
        {
            previewBuilding = Instantiate(building, buildingPosition, Quaternion.identity);
        }
    }

    private void OnMouseExit()
    {
        isHovered = false;
        hoverlay.GetComponent<Renderer>().material = grassMaterial;
        Destroy(previewBuilding);
    }

}
