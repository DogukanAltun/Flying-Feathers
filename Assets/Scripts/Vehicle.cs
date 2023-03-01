using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private int verticalspeed = 100;
    private GameObject Player;
    private VehicleManager manager;
    private Rigidbody physic;
    public static Vehicle instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Player = GameObject.FindWithTag("GridPosition");
        physic = GetComponent<Rigidbody>();
        manager = transform.parent.GetComponent<VehicleManager>();
    }
    void Update()
    {
      if (transform.position.z < Player.transform.position.z - 30)
      {
         manager.LocateVehicle(1000);     
      }
      MoveToPlayer();   
    }

    public void MoveToPlayer()
    {
        physic.velocity = new Vector3(0, 0, -verticalspeed);
    }

}
