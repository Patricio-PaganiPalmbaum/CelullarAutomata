using System.Collections.Generic;
using UnityEngine;

public class LeftSquareBracket : BrushShape
{
    private Vector2Int[] bracketDirections = new Vector2Int[]
    {
        Vector2Int.up,
        Vector2Int.up * 2,
        Vector2Int.up * 2 + Vector2Int.right,
        Vector2Int.up * 2 + Vector2Int.right * 2,
        Vector2Int.down,
        Vector2Int.down * 2,
        Vector2Int.down * 2 + Vector2Int.right,
        Vector2Int.down * 2 + Vector2Int.right * 2
    };

    public override List<Vector2Int> PaintGrid(Vector2Int position, int gridWitdh, int gridHeight)
    {
        List<Vector2Int> paintDirections = new List<Vector2Int>() { position };
        Vector2Int nextPosition = Vector2Int.zero;

        for (int i = 0; i < bracketDirections.Length; i++)
        {
            nextPosition = position + bracketDirections[i];

            if (!IsValidPosition(nextPosition, gridWitdh, gridHeight))
            {
                continue;
            }

            paintDirections.Add(nextPosition);
        }

        return paintDirections;
    }
}