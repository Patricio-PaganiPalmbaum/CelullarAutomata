using UnityEngine;

public abstract class GridProcessor : ScriptableObject
{
    public abstract int ProcessGrid(Vector2Int position, int[,] contenxt);
}