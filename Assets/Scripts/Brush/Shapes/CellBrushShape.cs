using System.Collections.Generic;
using UnityEngine;

public class CellBrushShape : BrushShape
{
    public override List<Vector2Int> PaintGrid(Vector2Int position, int gridWitdh, int gridHeigh)
    {
        return new List<Vector2Int>() { position };
    }
}