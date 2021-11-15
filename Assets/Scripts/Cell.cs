using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    // UI parameters

    public GameObject overlay;

    private bool isHovered = false;
    private bool isSelected = false;

    // Render parameters
    public GameObject forest;

    public GameObject residence;


    public GameObject powerplant;


    public GameObject industry;


    private GameObject renderObject;

    // Position
    public int x;
    public int y;


    // Game parameters
    public CellType type;

    public int power;

    public int pollution;

    public int production;

    public int value;


    private Color transparentColor;


    void Start()
    {
        Debug.Log("Created cell at: " + x + ", " + y);
        Debug.Log(overlay.GetComponent<Renderer>().material.color);
        this.SetType(this.type);
        transparentColor = new Color(0.113f, 0.455f, 0.165f, 1);
    }

    public void SetType(CellType type)
    {
        this.type = type;
        Destroy(renderObject);
        GetRenderObject();
        InstantiateObject();

        // TODO: Change the turn here

    }

    void GetRenderObject()
    {
        switch (this.type)
        {
            case CellType.Grass:
                renderObject = null;
                break;

            case CellType.Forest:
                renderObject = forest;
                break;

            case CellType.Residence:
                renderObject = residence;
                break;

            case CellType.Powerplant:
                renderObject = powerplant;
                break;

            case CellType.Industry:
                renderObject = industry;
                break;

            default:
                renderObject = null;
                break;
        }
    }

    void InstantiateObject()
    {
        if (renderObject != null)
        {
            Instantiate(renderObject, new Vector3(x, 0.35f, y), Quaternion.identity);
        }
    }

    private void OnMouseEnter()
    {
        isHovered = true;
        if (!isSelected)
        {
            overlay.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnMouseExit()
    {
        isHovered = false;
        if (!isSelected)
        {
            overlay.GetComponent<Renderer>().material.color = transparentColor;
        }
    }

    private void OnMouseDown()
    {
        if (isHovered)
        {
            isSelected = true;
            GameManager.instance.SelectCell(this.gameObject);
            overlay.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (!isHovered)
        {
            isSelected = false;
            GameManager.instance.SelectCell(null);
            overlay.GetComponent<Renderer>().material.color = transparentColor;
        }
    }
}