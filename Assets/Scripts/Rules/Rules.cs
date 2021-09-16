using UnityEngine;

public abstract class Rules : ScriptableObject
{
    public abstract int ApplyRules(int currentState, int environmentInfo);
}