using UnityEngine;

public abstract class StateProcessor : ScriptableObject
{
    public abstract int ProcessState(int state);
}