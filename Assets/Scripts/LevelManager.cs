using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public Level level;
    public Slider sliderpoint;
    public CharacterCont cont;
    public int levelIndex;
    void Start()
    {
        cont = FindObjectOfType<CharacterCont>();
        sliderpoint = FindObjectOfType<Slider>();
        levelIndex = PlayerPrefs.GetInt("levelIndex");
        level = levels[levelIndex];
        cont.AheadSpeed = level.AheadSpeed;
        cont.Speed =  level.SpeedForce;
        sliderpoint.maxValue = level.PointLimit;
    }
}
