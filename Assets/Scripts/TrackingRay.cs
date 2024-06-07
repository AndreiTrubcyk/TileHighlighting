using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrackingRay : MonoBehaviour
{
    private HighlightedObject _lastHighlightedGameObject;
    
    private Color originalColor;
    
    void Update()
    {
        var currentObject = GetHighlightedObject();
        var isNewObject = currentObject != _lastHighlightedGameObject;
        if (isNewObject)
        {
            if (_lastHighlightedGameObject != null)
            {
                _lastHighlightedGameObject.TakeOriginalColor();
            }
            
            if (currentObject != null)
            {
                currentObject.ChangeColor();
            }
            
            _lastHighlightedGameObject = currentObject;
        }
    }

    private HighlightedObject GetHighlightedObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit ))
        {
            if (hit.collider.CompareTag("Grass") || hit.collider.CompareTag("Bridge"))
            {
                var currentObject = hit.collider.GetComponent<HighlightedObject>();
                return currentObject;
            }
        }

        return null;
    }
}
