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
        newTower.GetComponent<Tower>().position = new int[] {
            (int)spawnPosition.x, (int)spawnPosition.y
        };
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
        List<Vector2> nearestTiles = new List<Vector2>(){topLeft, topRight, btmLeft, btmRight};

        Vector2 nearestTile = nearestTiles[0];
        float minimalEnemyDistance = Vector2.Distance(position, nearestTile);
        GameObject target = null;

        for (int i = 1; i < nearestTiles.Count; i++ ){
            Vector2 tile = nearestTiles[i];
            if (tile.x >= 0 && tile.x < (xSize)
            && (tile.y >= 0 && tile.y < (ySize))) {
                float distance = Vector2.Distance(position, tile);
                if (distance < minimalEnemyDistance) {
                    minimalEnemyDistance = distance;
                    nearestTile = tile;
                }
            }
        }

        int xTile = (int)nearestTile.x;
        int yTile = (int)nearestTile.y;

        if (xTile >= 0 && xTile < (xSize)
            && (yTile >= 0 && yTile < (ySize))) {
            target = Towers[(int)nearestTile.x, (int)nearestTile.y] != tower ? Towers[(int)nearestTile.x, (int)nearestTile.y]: null;
        }

        if (target != null) {
            Tower fuck = target.GetComponent<Tower>();
            Tower oldTower = tower.GetComponent<Tower>();
            if (fuck.Level == oldTower.Level) {
                fuck.Level *= 2;
                Towers[oldTower.position[0], oldTower.position[1]] = null;

                isAbleToSpawn = new List<Vector2>();
                for (int x = 0; x < xSize; ++x) {
                    for (int y = 0; y < ySize; ++y){
                        if (Towers[x,y] == null) {
                            isAbleToSpawn.Add(new Vector2(x, y));
                        }
                    }
                }

                Destroy(tower);
            }
        }

    }
}
