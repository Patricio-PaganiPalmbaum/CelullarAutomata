using UnityEngine;

public abstract class ColorGuide : ScriptableObject
{
    public abstract Color GetColor(int state);
}