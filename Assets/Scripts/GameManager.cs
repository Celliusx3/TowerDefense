using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Wave;
    private int gold;
    public int Health;
    private int nextTowerCost;

    public Text goldLabel;
    public Text nextTowerCostLabel;
    public GameObject gameOverPanel;

    public int Gold {
        get
        { 
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = gold.ToString();
        }
    }

    public int NextTowerCost {
        get
        { 
            return nextTowerCost;
        }
        set
        {
            nextTowerCost = value;
            nextTowerCostLabel.GetComponent<Text>().text = nextTowerCost.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OnRestartClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver() {
        gameOverPanel.SetActive(true);
    }
    public void OnRestartClicked(){
        Gold = 10000000;
        NextTowerCost = 60;
        gameOverPanel.SetActive(false);
    }
}
