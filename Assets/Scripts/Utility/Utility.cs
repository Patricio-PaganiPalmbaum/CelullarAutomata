using UnityEngine;

public static class Utility
{
    public static Vector2Int[] directions = new Vector2Int[]
    {
        Vector2Int.up,
        Vector2Int.up + Vector2Int.right,
        Vector2Int.right,
        Vector2Int.right + Vector2Int.down,
        Vector2Int.down,
        Vector2Int.down + Vector2Int.left,
        Vector2Int.left,
        Vector2Int.left + Vector2Int.up
    };

    public static Vector2Int[] diagonalDirections = new Vector2Int[]
    {
        Vector2Int.up + Vector2Int.right,
        Vector2Int.right + Vector2Int.down,
        Vector2Int.down + Vector2Int.left,
        Vector2Int.left + Vector2Int.up
    };

    public static int CircularLength(int value, int length)
    {
        if (value < 0)
        {
            value = length - 1;
        }
        else if (value >= length)
        {
            value = 0;
        }

        return value;
    }
}
