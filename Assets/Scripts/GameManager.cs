using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    // Hovered cell
    public int x;
    public int y;


    // Selected building
    public GameObject selectedBuilding;

    public int productionValue;

    public int pollutionValue;

    public int natureEquilibrium;




    void Awake()
    {
        instance = this;
    }


    public event Action onNextTurn;


    public void nextTurn()
    {
        onNextTurn?.Invoke();
    }

    // Generate Terrain

    // Function to handle selected building change 
    // Function to calculate production value
    // Function to calculate pollution value
    // Function to update equilibrium meter
    // Function to remember equilibrium meter
    // Function to change arena state





}
