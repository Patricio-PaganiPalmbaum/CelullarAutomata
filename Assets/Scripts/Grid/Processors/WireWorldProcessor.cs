using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WireWorldProcessor : GridProcessor
{
    private Dictionary<int, int> cellValues = new Dictionary<int, int>() { { 0, 0 }, { 1, 1 }, { 2, 0 }, { 3, 0 } };

    public override int ProcessGrid(Vector2Int position, int[,] contenxt)
    {
        Vector2Int nextPosition = Vector2Int.zero;
        int electronTails = 0;

        for (int i = 0; i < Utility.directions.Length; i++)
        {
            nextPosition = position + Utility.directions[i];
            nextPosition.x = Utility.CircularLength(nextPosition.x, contenxt.GetLength(0));
            nextPosition.y = Utility.CircularLength(nextPosition.y, contenxt.GetLength(1));

            electronTails += cellValues[contenxt[nextPosition.x, nextPosition.y]];
        }

        return electronTails;
    }
}