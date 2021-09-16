using System.Collections.Generic;
using UnityEngine;

public class QuadBrushShape : BrushShape
{
    public override List<Vector2Int> PaintGrid(Vector2Int position, int gridWitdh, int gridHeigh)
    {
        List<Vector2Int> paintPositions = new List<Vector2Int>() { position };

        Vector2Int nextPosition = Vector2Int.zero;

        for (int i = 0; i < Utility.directions.Length; i++)
        {
            nextPosition = position + Utility.directions[i];

            if (!IsValidPosition(nextPosition, gridWitdh, gridHeigh))
            {
                continue;
            }

            paintPositions.Add(nextPosition);
        }

        return paintPositions;
    }
}