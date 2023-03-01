using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlace : MonoBehaviour
{
    public GameObject destination;
    public Transform leader;
    public static BirdPlace instance;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        leader = transform.GetChild(0).transform;
    }

    public struct Place
    {
        public Vector3 position;
        public GameObject grid;
    }

    public Place GetPosition(GameObject gameObject)
    {
        Place place = new Place();
        for (int i = 1; i < transform.childCount; i++)
        {
             if (transform.GetChild(i).transform.GetComponent<Enum>().hierarcy == Enum.Hierarcy.Not)
             {
                transform.GetChild(i).transform.GetComponent<Enum>().hierarcy = Enum.Hierarcy.Yes;
                destination = transform.GetChild(i).transform.GetChild(0).gameObject;
                Vector3Int x = destination.GetComponent<coordinatelabeler>().coordinates;
                gameObject.GetComponent<BirdMoves>().number = i;
                place.position = x;
                place.grid = transform.GetChild(i).transform.gameObject; 
                return place;
             }
        }
        place.position = leader.position;
        place.grid = leader.gameObject;
        return place;
    }

    public void Feather(int i)
    {
        destination = transform.GetChild(i).transform.GetChild(1).gameObject;
        destination.SetActive(true);
        StartCoroutine(StopFeather(i));
    }
    public IEnumerator StopFeather(int i)
    {
        yield return new WaitForSeconds(1f);
        destination = transform.GetChild(i).transform.GetChild(1).gameObject;
        destination.SetActive(false);
    }
    public Place GetLeader()
    {
        Place place = new Place();
        leader.GetComponent<Enum>().hierarcy = Enum.Hierarcy.Yes;
        place.position = leader.position;
        place.grid = leader.gameObject;
        return place;
    }
  
    public void BreakPosition(int number)
    {
        transform.GetChild(number).transform.GetComponent<Enum>().hierarcy = Enum.Hierarcy.Not;
    }

  

}
