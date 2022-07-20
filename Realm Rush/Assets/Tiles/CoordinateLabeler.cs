using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro _label;
    Vector2Int _coordinates = new Vector2Int();

    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }


    void DisplayCoordinates()
    {
        _coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        _coordinates.y = Mathf.RoundToInt(transform.parent.position.z/ UnityEditor.EditorSnapSettings.move.y);
        _label.text = _coordinates.x + "," + _coordinates.y;

    }

    void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }
}
