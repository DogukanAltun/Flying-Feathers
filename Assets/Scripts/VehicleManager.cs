using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public GameObject[] Vehicle;
    public GameObject Player;
    public GameObject[] Grid;
    public int GridLength;
    private int VehicleLength;
    private int EmptyLength = 3;
    [SerializeField] private int BeginDistance;
    private AudioSource audioPlayer;
    public static VehicleManager instance;
    private void Awake()
    {
        instance = this;
       
    }
    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("GridPosition");
        VehicleLength = transform.childCount;
        GridLength = Grid.Length;
        Debug.Log(VehicleLength);
        for (int i = 0; i < VehicleLength; i++)
        {
            Vehicle[i] = transform.GetChild(i).transform.gameObject;
        }
        LocateVehicle(BeginDistance);
    }

    public void LocateVehicle(int Distance)
    { 
      for (int i = 0; i < VehicleLength; i++)
      {
         Vehicle[i].gameObject.SetActive(true);
         var x = Grid[i].transform.GetChild(0).transform.gameObject.GetComponent<coordinatelabeler>().coordinates.x;
         var y = Grid[i].transform.GetChild(0).transform.gameObject.GetComponent<coordinatelabeler>().coordinates.y;
         Vector3 vector3 = new Vector3(x, y, Player.transform.position.z + Distance);
         Vehicle[i].transform.position = vector3;
         audioPlayer.Play();
      }
      for (int i = 0; i < EmptyLength; i++)
      {
         int Empty = Random.Range(0, VehicleLength);
         Vehicle[Empty].gameObject.SetActive(false);
      }
    }
}
