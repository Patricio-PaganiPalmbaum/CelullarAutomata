using System.Collections.Generic;
using UnityEngine;

public class CrossBrushShape : BrushShape
{
    public override List<Vector2Int> PaintGrid(Vector2Int position, int gridWitdh, int gridHeight)
    {
        List<Vector2Int> paintPositions = new List<Vector2Int>() { position };
        Vector2Int nextPosition = Vector2Int.zero;

        for (int i = 0; i < Utility.diagonalDirections.Length; i++)
        {
            nextPosition = position + Utility.diagonalDirections[i];

            if (!IsValidPosition(nextPosition, gridWitdh, gridHeight))
            {
                continue;
            }

            paintPositions.Add(nextPosition);
        }

        return paintPositions;
    }
}