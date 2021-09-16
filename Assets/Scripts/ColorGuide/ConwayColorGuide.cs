using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ConwayColorGuide : ColorGuide
{
    private Dictionary<int, Color> colorGuide;

    public ConwayColorGuide()
    {
        colorGuide = new Dictionary<int, Color>()
        {
            {0, Color.black },
            {1, Color.white }
        };
    }

    public override Color GetColor(int state)
    {
        return colorGuide[state];
    }
}