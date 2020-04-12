using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : MonoBehaviour
{
    public GameObject bullet;
    private int level;
    private Text towerLevelLabel;
    public float startFireRate;
    private float currentFireRate;
    private int currentDamage;
    public int startDamage;
    public int numberOfTargets = 1;
    public bool canPoison = false;

    public int Level {
        get
        { 
            return level;
        }
        set
        {
            level = value;
            towerLevelLabel.text = level.ToString();
            setFireRate(level);
            setDamage(level);
        }
    }

    public int CurrentDamage {
        get
        {
            return currentDamage;
        }
    }
    public float CurrentFireRate {
        get
        {
            return currentFireRate;
        }
    }

    void OnEnable() {
        towerLevelLabel = GetComponentInChildren<Text>();
        Level = 1;
    }

    private void setDamage(int level) {
        currentDamage = startDamage + (10 * level);
    }

    private void setFireRate(int level) {
        currentFireRate = Mathf.Max(startFireRate - (0.05f * level), 0.01f);
    }
}
