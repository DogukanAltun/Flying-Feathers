using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "level")]
public class Level : ScriptableObject
{
    public int PointLimit;

    public float AheadSpeed;

    public float SpeedForce;
}
