using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Action<int[,]> OnUpdateGrid = delegate { };
    public Action<Vector2Int, int> OnUpdateCell = delegate { };

    public Rules rulesToApply;
    public GridProcessor gridProcessor;

    public int gridWidth;
    public int gridHeight;

    public int[,] CurrentGrid { get; private set; }
    private int[,] nextGrid;

    private void Awake()
    {
        CurrentGrid = new int[gridWidth, gridHeight];
        nextGrid = new int[gridWidth, gridHeight];
    }

    public void PaintGrid(int [,] newGridState)
    {
        CurrentGrid = newGridState;
        OnUpdateGrid.Invoke(CurrentGrid);
    }

    public void CalculateNextGrid()
    {
        Vector2Int currentPosition = Vector2Int.zero;

        for (int i = 0; i < CurrentGrid.GetLength(0); i++)
        {
            currentPosition.x = i;
            for (int j = 0; j < CurrentGrid.GetLength(1); j++)
            {
                currentPosition.y = j;
                nextGrid[i, j] = rulesToApply.ApplyRules(CurrentGrid[i, j], gridProcessor.ProcessGrid(currentPosition, CurrentGrid));
            }
        }
    }

    public void DisplayNextGrid()
    {
        CurrentGrid = nextGrid;
        nextGrid = new int[gridWidth, gridHeight];
        OnUpdateGrid.Invoke(CurrentGrid);
    }
}