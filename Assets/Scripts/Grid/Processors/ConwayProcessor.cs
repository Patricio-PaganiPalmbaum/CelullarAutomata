using UnityEngine;

[CreateAssetMenu()]
public class ConwayProcessor : GridProcessor
{
    public override int ProcessGrid(Vector2Int position, int[,] contenxt)
    {
        Vector2Int nextPosition = Vector2Int.zero;
        int lives = 0;

        for (int i = 0; i < Utility.directions.Length; i++)
        {
            nextPosition = position + Utility.directions[i];
            nextPosition.x = Utility.CircularLength(nextPosition.x, contenxt.GetLength(0));
            nextPosition.y = Utility.CircularLength(nextPosition.y, contenxt.GetLength(1));

            lives += contenxt[nextPosition.x, nextPosition.y];
        }

        return lives;
    }
}