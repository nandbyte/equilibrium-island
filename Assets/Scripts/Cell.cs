using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int power;
    public int pollution;

    public int production;

    public int value;

    public CellType type;

    void Start()
    {
        RenderCell();
    }

    void RenderCell()
    {
        switch (type)
        {
            case CellType.Grass:
                Debug.Log("Grass");
                break;
            case CellType.Forest:
                Debug.Log("Forest");
                break;
            case CellType.Residence:
                Debug.Log("Residence");
                break;
            case CellType.Powerplant:
                Debug.Log("Powerplant");
                break;
            case CellType.Industry:
                Debug.Log("Industry");
                break;
            default:
                Debug.Log("Grass");
                break;
        }
    }


}
