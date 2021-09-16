using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ConwaysRules : Rules
{
    private Dictionary<int, Dictionary<int, int>> rules;

    public ConwaysRules()
    {
        rules = new Dictionary<int, Dictionary<int, int>>()
        {
            {0, new Dictionary<int, int>() //Dead actions.
                {
                    {0, 0 },
                    {1, 0 },
                    {2, 0 },
                    {3, 1 }, //Reproduction.
                    {4, 0 },
                    {5, 0 },
                    {6, 0 },
                    {7, 0 },
                    {8, 0 }
                }
            },
            {1, new Dictionary<int, int>() //Live actions.
                {
                    {0, 0 }, //Underpopulation
                    {1, 0 }, //Underpopulation
                    {2, 1 }, //Lives on to the next generation.
                    {3, 1 }, //Lives on to the next generation.
                    {4, 0 }, //Overpopulation.
                    {5, 0 }, //Overpopulation.
                    {6, 0 }, //Overpopulation.
                    {7, 0 }, //Overpopulation.
                    {8, 0 }, //Overpopulation.
                }
            }
        };
    }

    public override int ApplyRules(int currentState, int environmentInfo)
    {
        return rules[currentState][environmentInfo];
    }
}