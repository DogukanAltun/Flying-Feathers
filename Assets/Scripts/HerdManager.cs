using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerdManager : MonoBehaviour
{
    [SerializeField] private GameObject Leader;
    public GameObject leader { get { return Leader; } set { Leader = value; } }
    public GameObject[] Herd;
    private int HerdLength;
    private int LeadersNumber;
    public bool isLeaderDied;
    public bool isleaderDied { get { return isLeaderDied; } set { isLeaderDied = value; } }
    public int birdCount = 1;

    public static HerdManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        HerdLength = gameObject.transform.childCount;
        for (int i = 0; i < HerdLength; i++) 
        {
            Herd[i] = gameObject.transform.GetChild(i).gameObject;
        }
        Leader = Herd[0];
    }

    private void Update()
    {
        if (isLeaderDied == true)
        {
            Invoke("ChoiceNewLeader",0.5f);
        }
    }

    private void isThereLeader()
    {
        for (int i = 0; i < HerdLength; i++)
        {
            if (Herd[i].gameObject.activeInHierarchy)
            {
                return;
            }
        }
        CanvasManager.Instance.GameOver();
    }
    private void ChoiceNewLeader()
    {
        if (Herd != null)
        {
            for (int i = 0; i < HerdLength; i++)
            {
                if (Herd[LeadersNumber + i].GetComponent<Enum>().hierarcy != Enum.Hierarcy.Died)
                {
                    Leader = Herd[LeadersNumber + i];
                    Leader.GetComponent<Enum>().hierarcy = Enum.Hierarcy.Leader;
                    int j = Leader.GetComponent<BirdMoves>().number;
                    FindObjectOfType<BirdPlace>().BreakPosition(j);
                    Leader.GetComponent<BirdMoves>().GetLeader();
                    isLeaderDied = false;
                    return;
                }
            }
            isThereLeader();
        }
    }
}
