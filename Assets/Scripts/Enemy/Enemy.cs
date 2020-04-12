using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    private float maxMoveSpeed;
    private float currentMoveSpeed;
    private Text healthLabel;

    void OnEnable() {
        healthLabel = GetComponentInChildren<Text>();
        MaxMoveSpeed = 2.5f;
    }
    
    public int CurrentHealth {
        get
        { 
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            healthLabel.text = currentHealth.ToString();
        }
    }
    public int MaxHealth {
        get
        { 
            return maxHealth;
        }
        set
        {
            maxHealth = value;
            CurrentHealth = maxHealth;
        }
    }
    public float CurrentMoveSpeed {
        get
        { 
            return currentMoveSpeed;
        }
        set
        {
            currentMoveSpeed = value;
        }
    }
    public float MaxMoveSpeed {
        get
        { 
            return maxMoveSpeed;
        }
        set
        {
            maxMoveSpeed = value;
            CurrentMoveSpeed = maxMoveSpeed;
        }
    }

    IEnumerator Poison(int damage) {
        while(currentHealth > 0) {
            currentHealth -= damage;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void ApplyPoison(int damage) {
        StartCoroutine(Poison(damage));
    }
}

