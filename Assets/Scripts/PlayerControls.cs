using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject[] buildings;

    void Start()
    {

    }


    void Update()
    {

    }

    void SelectResidence()
    {
        GameManager.instance.selectedBuilding = buildings[0];
    }

    void SelectPowerplant()
    {
        GameManager.instance.selectedBuilding = buildings[1];
    }

    void SelectIndustry()
    {
        GameManager.instance.selectedBuilding = buildings[2];
    }
}
