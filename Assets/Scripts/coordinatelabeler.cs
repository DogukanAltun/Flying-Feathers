using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coordinatelabeler : MonoBehaviour
{
    public TextMeshPro label;
    public Vector3Int coordinates;
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.y);
        coordinates.z = Mathf.RoundToInt(transform.parent.position.z);
        label.text = coordinates.x + "," + coordinates.y;
    }
}
