using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    TextMeshPro _label;
    Vector2Int _coordinates = new Vector2Int();
    Waypoint wayPoint;

    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        _label.enabled = false;
        wayPoint = GetComponentInParent<Waypoint>();
        _label.color = defaultColor;
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
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

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _label.enabled = !_label.IsActive();
        }
            
    }

    void ColorCoordinates()
    {
        if (wayPoint.IsPlaceable)
        {
            _label.color = defaultColor;
        }
        else
        {
            _label.color = blockedColor;
        }
    }
}
