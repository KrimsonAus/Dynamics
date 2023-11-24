using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grid : MonoBehaviour
{
    public int cellSizeX;
    public int cellSizeY;
    public Cell[] cellObj;

    int player;

    public GameObject cell;
    public Color[] cellColors;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        cellObj = new Cell[(8+cellSizeX)*(4+cellSizeY)];

        for (int x = 0; x < cellSizeX; x++)
        {
            for (int y = 0; y < cellSizeY; y++)
            {
                GameObject co = Instantiate(cell, new Vector2(x-8, y-4), Quaternion.identity);
                cellObj[index] = co.GetComponent<Cell>();
                cellObj[index].transform.parent = transform;
                cellObj[index].index = index;
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CellQuery()
    {
        
    }
}
