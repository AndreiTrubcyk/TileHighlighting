using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightedObject : MonoBehaviour
{
    private Color _originalColor;
    private Color _color = Color.gray;
    private Material _material;
    
    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _originalColor = _material.color;
    }

    public void TakeOriginalColor()
    {
        _material.color = _originalColor;
    }

    public void ChangeColor()
    {
        _material.color = _color;
    }
}
