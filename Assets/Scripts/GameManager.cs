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

    public int Gold {
        get
        { 
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
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
        Gold = 160;
        NextTowerCost = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
