using UnityEngine;

[CreateAssetMenu()]
public class WireWorldStateProcessor : StateProcessor
{
    public override int ProcessState(int state)
    {
        if (state == 3)
        {
            return 0;
        }

        return state + 1;
    }
}