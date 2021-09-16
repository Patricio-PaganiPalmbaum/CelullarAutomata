using UnityEngine;

[CreateAssetMenu()]
public class ConwayStateProcessor : StateProcessor
{
    public override int ProcessState(int state)
    {
        if (state == 0)
        {
            return 1;
        }

        return 0;
    }
}