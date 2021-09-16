using System.Collections.Generic;
using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public CellManager cellManager;
    public GridManager gridManager;
    public StateProcessor stateProcessor;

    private Cell currentCell;
    private BrushShape currentBrush;
    private Dictionary<EBrushType, BrushShape> brushs;
    private int[,] grid;

    private void Start()
    {
        SubscribeToCells();
        grid = gridManager.CurrentGrid;

        brushs = new Dictionary<EBrushType, BrushShape>()
        {
            {EBrushType.Cell, new CellBrushShape() },
            {EBrushType.Quad, new QuadBrushShape() },
            {EBrushType.Cross, new CrossBrushShape() },
            {EBrushType.LeftSquareBracket, new LeftSquareBracket() },
            {EBrushType.RightSquareBracket, new RightSquareBracket() }
        };

        currentBrush = brushs[EBrushType.Cell];
    }

    private void SubscribeToCells()
    {
        for (int i = 0; i < cellManager.CellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < cellManager.CellGrid.GetLength(1); j++)
            {
                cellManager.CellGrid[i, j].OnMouseEnterCell += OnMouseEnterCell;
                cellManager.CellGrid[i, j].OnMouseExitCell += OnMouseExitCell;
            }
        }
    }

    private void OnMouseEnterCell(Cell cell)
    {
        currentCell = cell;
    }

    private void OnMouseExitCell(Cell cell)
    {
        currentCell = null;
    }

    private void Update()
    {
        if (currentCell && Input.GetMouseButtonDown(0))
        {
            PaintSelectedCells(currentBrush.PaintGrid(currentCell.gridPosition, grid.GetLength(0), grid.GetLength(1)));
        }
    }

    private void PaintSelectedCells(List<Vector2Int> cellsToPaint)
    {
        grid = gridManager.CurrentGrid;

        foreach (Vector2Int cellPosition in cellsToPaint)
        {
            grid[cellPosition.x, cellPosition.y] = stateProcessor.ProcessState(grid[cellPosition.x, cellPosition.y]);
        }

        gridManager.PaintGrid(grid);
    }

    public void SetCurrentBrush(int brush)
    {
        currentBrush = brushs[(EBrushType)brush];
    }
}