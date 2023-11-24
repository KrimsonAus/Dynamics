using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [HideInInspector] SpriteRenderer spriteRenderer;
    public int ID;
    public int index;
    Grid grid;

    [HideInInspector] public bool changed;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = grid.cellColors[ID];

        if (ID == 1 && index<(grid.cellSizeX*grid.cellSizeY) - 1 && !changed)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                grid.cellObj[index + 1].ID = ID;
                grid.cellObj[index + 1].changed = true;
                ID = 0;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                grid.cellObj[index - 1].ID = ID;
                grid.cellObj[index - 1].changed = true;
                ID = 0;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                grid.cellObj[index + 9].ID = ID;
                grid.cellObj[index + 9].changed = true;
                ID = 0;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                grid.cellObj[index - 9].ID = ID;
                grid.cellObj[index - 9].changed = true;
                ID = 0;
            }
        }
        if (changed)
        {
            changed = false;
        }
    }
}
