using UnityEngine;

public class CellManager : MonoBehaviour
{
    public Cell cellPrefab;
    public GridManager gridManager;
    public ColorGuide colorGuide;

    public int startX;
    public int startZ;

    public float cellWidth;
    public float cellHeigh;

    public int gridWidth;
    public int gridHeight;

    public Cell[,] CellGrid { get; private set; }

    private void Awake()
    {
        CreateGrid();

        gridManager.OnUpdateGrid += UpdateCellsState;
        gridManager.OnUpdateCell += UpdateCellState;
    }

    private void CreateGrid()
    {
        CellGrid = new Cell[gridWidth, gridHeight];

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                CellGrid[i, j] = Instantiate(cellPrefab, new Vector3(startX + cellWidth * i, startZ + cellHeigh * j, 0f), Quaternion.identity, transform);
                CellGrid[i, j].gridPosition = new Vector2Int(i, j);
            }
        }
    }

    public void UpdateCellsState(int[,] currentState)
    {
        for (int i = 0; i < CellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < CellGrid.GetLength(1); j++)
            {
                CellGrid[i, j].SetColor(colorGuide.GetColor(currentState[i, j]));
            }
        }
    }

    public void UpdateCellState(Vector2Int cell, int state)
    {
        CellGrid[cell.x, cell.y].SetColor(colorGuide.GetColor(state));
    }
}