using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WireWorldColorGuide : ColorGuide
{
    private Dictionary<int, Color> colorGuide;

    public WireWorldColorGuide()
    {
        colorGuide = new Dictionary<int, Color>()
        {
            {0, Color.black },
            {1, Color.blue },
            {2, Color.red },
            {3, Color.yellow }
        };
    }

    public override Color GetColor(int state)
    {
        return colorGuide[state];
    }
}