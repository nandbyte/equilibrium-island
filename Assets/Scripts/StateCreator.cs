using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCreator : MonoBehaviour
{
    [SerializeField]
    private int terrainSize = 8;

    [SerializeField]
    private int cellSize = 1;


    [SerializeField]
    private float seaLevel = -1;

    [SerializeField]
    private GameObject cell;



    // Start is called before the first frame update
    void Start()
    {
        // Initialize the state 
        GameManager.instance.currentState = new GameObject[8, 8];

        // Render the state
        RenderState();


    }

    // Update is called once per frame
    void Update()
    {

    }


    void RenderState()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameManager.instance.currentState[i, j] = Instantiate(cell, new Vector3(i, 0, j), transform.rotation);

                GameManager.instance.currentState[i, j].GetComponent<Cell>().type = CellType.Grass;


                GameManager.instance.currentState[i, j].GetComponent<Cell>().x = i;


                GameManager.instance.currentState[i, j].GetComponent<Cell>().y = j;
            }
        }
    }
}
