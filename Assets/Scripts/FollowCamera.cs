using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset; 
    private void Start()
    { 
        offset = transform.position - target.transform.position;
    }
    private void LateUpdate()
    {
        Vector3 newposition = Vector3.Lerp(transform.position, target.position + offset, 0.7f);
        transform.position = newposition;
    }
}

