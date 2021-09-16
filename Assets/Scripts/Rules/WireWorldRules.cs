using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WireWorldRules : Rules
{
    private Dictionary<int, Func<int, int>> rules;

    public WireWorldRules()
    {
        rules = new Dictionary<int, Func<int, int>>()
        {
            {0, (n) => 0 },                        //Empty
            {1, (n) => 2 },                        //Electron head.
            {2, (n) => 3 },                        //Electron tail
            {3, (n) => (n > 0 && n <= 2) ? 1 : 3 } //Conductor
        };
    }

    public override int ApplyRules(int currentState, int environmentInfo)
    {
        return rules[currentState].Invoke(environmentInfo);
    }
}