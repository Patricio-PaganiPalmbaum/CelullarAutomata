using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Action<Cell> OnClick = delegate { };
    public Action<Cell> OnMouseEnterCell = delegate { };
    public Action<Cell> OnMouseExitCell = delegate { };

    public Vector2Int gridPosition;
    private Material material;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown()
    {
        OnClick.Invoke(this);
    }

    private void OnMouseEnter()
    {
        OnMouseEnterCell.Invoke(this);
    }

    private void OnMouseExit()
    {
        OnMouseExitCell.Invoke(this);
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }
}