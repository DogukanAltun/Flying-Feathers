using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoves : MonoBehaviour
{
    [SerializeField] private GameObject BirdGrid;
    private BirdPlace birdPlace;
    private Vector3 Distance;
    [SerializeField] public int number;
    private bool isLocated;
    private Enum status;
  
    private void Start()
    {
        status = GetComponent<Enum>();
        birdPlace = BirdPlace.instance;
    }

    public void GetPosition()
    {
        var place = birdPlace.GetPosition(gameObject);
        transform.position =  place.position;
        BirdGrid = place.grid;
        Distance = transform.position - BirdGrid.transform.position;
    }

    public void GetLeader()
    {
        transform.position = birdPlace.GetLeader().position;
        BirdGrid = birdPlace.GetLeader().grid;
        Distance = transform.position - BirdGrid.transform.position;
    }

    public void BreakPosition()
    {
        birdPlace.BreakPosition(number);
        isLocated = false;
    }

    public void FeatherAnim()
    {
       birdPlace.Feather(number);
    }

    private void Update()
    {
        if(status.hierarcy == Enum.Hierarcy.Child)
        {
            if (isLocated == false)
            {
                GetPosition();
                isLocated = true;
            }
            Vector3 newposition = Vector3.Lerp(transform.position, BirdGrid.transform.position + Distance, 0.8f);
            transform.position = newposition;
        }
        else if(status.hierarcy == Enum.Hierarcy.Leader)
        {
            if (isLocated == false)
            {
                GetLeader();
                isLocated = true;
            }
            Vector3 newposition = Vector3.Lerp(transform.position, BirdGrid.transform.position + Distance, 0.8f);
            transform.position = newposition;
        }
    }

}
