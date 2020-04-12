using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public int xSize, ySize;
    public GameObject[] spawanableTowers;
    private GameObject[,] Towers;
    private List<Vector2> isAbleToSpawn;

    private Vector2 startPosition = new Vector2(-1f, -2f);

    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
    
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Towers = new GameObject[xSize, ySize];
        isAbleToSpawn = new List<Vector2>();
        for (int x = 0; x < xSize; ++x) {
            for (int y = 0; y < ySize; ++y){
                isAbleToSpawn.Add(new Vector2(x, y));
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewTower() {
        if (GameManager.Gold < GameManager.NextTowerCost || isAbleToSpawn.Count <= 0)
            return;

        int position = Random.Range(0, isAbleToSpawn.Count);
        
        Vector2 spawnPosition = isAbleToSpawn[position];


        GameObject newTower = Instantiate(spawanableTowers[Random.Range(0, spawanableTowers.Length)], new Vector3(startPosition.x + spawnPosition.x, startPosition.y + spawnPosition.y, 0), transform.rotation);
        Towers[(int)spawnPosition.x, (int)spawnPosition.y] = newTower;
        isAbleToSpawn.RemoveAt(position);

        GameManager.Gold -= GameManager.NextTowerCost;
        GameManager.NextTowerCost += 20;
    }

    public void Combine(GameObject tower) {
        Vector2 position = (Vector2)tower.transform.position - startPosition;
        Debug.Log(position);

        float smallX = Mathf.Floor(position.x);
        float smallY = Mathf.Floor(position.y);
        float highX = Mathf.Ceil(position.x);
        float highY = Mathf.Ceil(position.y);
        Vector2 topLeft = new Vector2(smallX, smallY);
        Vector2 topRight = new Vector2(smallX,highY);
        Vector2 btmLeft = new Vector2(highX, smallY);
        Vector2 btmRight = new Vector2(highX, highY);
        List<Vector2> test = new List<Vector2>(){topLeft, topRight, btmLeft, btmRight};

        float minimalEnemyDistance = float.MaxValue;
        GameObject target = null;


        foreach (Vector2 enemy in test)
        {
            if (enemy.x >= 0 && enemy.x < (xSize)
            && (enemy.y >= 0 && enemy.y < (ySize))) {
                GameObject gg = Towers[(int)enemy.x, (int)enemy.y];
                if (gg != null && tower != gg) {
                    float distance = Vector2.Distance(position, enemy);
                    if (distance < minimalEnemyDistance) {
                        minimalEnemyDistance = distance;
                        target = gg;
                    }
                }
            }
        }

        if (target != null) {
            Tower fuck = target.GetComponent<Tower>();
            fuck.Level += 1;
            Destroy(tower);
        }

    }
}
