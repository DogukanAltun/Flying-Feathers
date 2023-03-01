using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdStatus : MonoBehaviour
{
    [SerializeField] private bool isThereEgg;
    [SerializeField] private HerdManager herd;
    private int HerdLength;
    private AudioSource audioPlayer;
    public CharacterCont characterController;
    [SerializeField] private GameObject Egg;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        herd = GetComponentInParent<HerdManager>();
        Egg.SetActive(false);
    }

    private IEnumerator EggSetting(GameObject other)
    {
        other.gameObject.SetActive(false);
        StartCoroutine(CanvasManager.Instance.IncreasePoint());
        yield return new WaitForSeconds(2f);
        other.gameObject.SetActive(true);
    }

    private void DieBird(GameObject bird)
    {
        BirdMoves birdMoves = bird.GetComponent<BirdMoves>();
        if (bird.GetComponent<Enum>().hierarcy == Enum.Hierarcy.Leader)
        {
            herd.isleaderDied = true;
        }
        bird.GetComponent<Enum>().hierarcy = Enum.Hierarcy.Died;
        birdMoves.FeatherAnim();
        birdMoves.BreakPosition();
        birdMoves.enabled = false;
        Invoke("AfterDie", 1f);
        birdMoves.enabled = true;
    }
    private void AfterDie()
    {
        gameObject.SetActive(false);
        isThereEgg = false;
        herd.birdCount -= 1;
        CanvasManager.Instance.birdCount();
        Debug.Log(herd.birdCount);
    }
    private void SpawnBird()
    {
        HerdLength = herd.transform.childCount;
        for (int i = 0; i < HerdLength; i++)
        {
            if (herd.Herd[i].activeInHierarchy == false && isThereEgg == true)
            {
                herd.Herd[i].SetActive(true);
                herd.Herd[i].GetComponent<Enum>().hierarcy = Enum.Hierarcy.Child;
                isThereEgg = false;
                herd.birdCount += 1;
                CanvasManager.Instance.birdCount();
                Debug.Log(herd.birdCount);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lr")
        {
            characterController.left = false;
        }
        if (other.tag == "rg")
        {
            characterController.right = false;
        }
        if (other.tag == "lr")
        {
            characterController.left = false;
        }
        if(other.tag == "rg")
        {
            characterController.right = false;
        }
        if(other.tag == "Enemy")
        {
            DieBird(gameObject);
            Egg.SetActive(false);

        }
        else if (other.tag == "Egg")
        {
            if (isThereEgg == false)
            {
                audioPlayer.Play();
                isThereEgg = true;
                Egg.SetActive(true);
                StartCoroutine(EggSetting(other.gameObject));
            }
        }
        else if(other.tag == "EggBirth" && isThereEgg == true)
        {
            Egg.SetActive(false);
            SpawnBird();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "lr")
        {
            characterController.left = true;
        }
        if (other.tag == "rg")
        {
            characterController.right = true;
        }
    }
}
