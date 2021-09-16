using System.Collections.Generic;
using UnityEngine;

public abstract class BrushShape
{
    public EBrushType brushType;

    public abstract List<Vector2Int> PaintGrid(Vector2Int position, int gridWitdh, int gridHeight);

    protected bool IsValidPosition(Vector2Int position, int gridWidth, int gridHeight)
    {
        if (position.x < 0 || position.y < 0 || position.x >= gridWidth || position.y >= gridHeight)
        {
            return false;
        }

        return true;
    }
}