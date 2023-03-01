using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollider : MonoBehaviour
{
    private Vector3 vector;
    private Vector3 bordersVector;
    private GameObject borders;

    private void Start()
    {
        vector = new Vector3(0, 0, 3000);
        bordersVector = new Vector3(0, 0, 1000);
        borders = GameObject.FindGameObjectWithTag("Borders");
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GridPosition")
        {
            gameObject.transform.position += vector;
            borders.transform.position += bordersVector;
        }
    }
}
