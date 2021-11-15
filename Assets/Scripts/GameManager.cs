using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    // State
    public GameObject[,] currentState;
    public GameObject[,] previousState;

    // Cell
    public GameObject selectedCell;
    public GameObject hoveredCell;



    // Selected building
    public GameObject selectedBuilding;

    public int productionValue;

    public int pollutionValue;

    public int natureEquilibrium;





    void Awake()
    {
        // Initialize singleton
        instance = this;

    }

    void Start()
    {

    }


    public void SelectCell(GameObject cell)
    {
        selectedCell = cell;
        Debug.Log("Selected cell number: " + selectedCell.GetComponent<Cell>().x + " " + selectedCell.GetComponent<Cell>().y);

    }

    // Generate Terrain

    // Function to handle selected building change 
    // Function to calculate production value
    // Function to calculate pollution value
    // Function to update equilibrium meter
    // Function to remember equilibrium meter
    // Function to change arena state





}
