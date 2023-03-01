using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CanvasManager : MonoBehaviour
{
    public Text Point;
    public Text text;
    public Text textBirdCount;
    public GameObject GameOverPanel;
    public GameObject NextLevelPanel;
    public int TotalPoint;
    public int BirdCount;
    [SerializeField] private HerdManager herd;
    public Slider sliderpoint;
    public LevelManager levelManager;
    public static CanvasManager Instance;

    public void Awake()
    {
        Instance = this;
        GameOverPanel = transform.GetChild(0).gameObject;
        NextLevelPanel = transform.GetChild(1).gameObject;
    }

    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        sliderpoint = FindObjectOfType<Slider>(); 
        herd = FindObjectOfType<HerdManager>();
        Point.text = ("0");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public IEnumerator IncreasePoint()
    {
        int birdCount = herd.birdCount;
        for (int i = 0; i < birdCount; i++)
        {
            TotalPoint++;
            sliderpoint.value = TotalPoint;
            Point.text = ("" + TotalPoint);
            if(TotalPoint == sliderpoint.maxValue)
            {
               NextLevel();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void birdCount()
    {
        textBirdCount.text = ("x " + herd.birdCount);
    }
    public void NextLevel()
    {

        Time.timeScale = 0;
        NextLevelPanel.SetActive(true);
        if (PlayerPrefs.GetInt("levelIndex") <= levelManager.levels.Length)
        {
            PlayerPrefs.SetInt("levelIndex", levelManager.levelIndex += 1);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }
}
