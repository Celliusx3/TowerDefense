using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    private Tower tower;

    // Use this for initialization
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        tower = gameObject.GetComponentInParent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesInRange.Sort(SortByDistance);
        bool hasShot = false;
        for (int i = 0; i < tower.numberOfTargets; i ++) {
            if (enemiesInRange.Count > i) {
                if (Time.time - lastShotTime > tower.CurrentFireRate)
                {
                    Shoot(enemiesInRange[i].GetComponent<Collider2D>());
                    hasShot = true;
                }
            }
        }

        if (hasShot) 
        {
            lastShotTime = Time.time;
        }
    }

    private void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            // EnemyDesctructionDelegate del =
            //     other.gameObject.GetComponent<EnemyDestructionDelegate>();
            // del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log(other);
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            // EnemyDestructionDelegate del =
            //     other.gameObject.GetComponent<EnemyDestructionDelegate>();
            // del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    private void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = tower.bullet;
        GameObject newBullet = (GameObject) Instantiate(bulletPrefab);
        newBullet.transform.position = gameObject.transform.position;
        Bullet bulletComp = newBullet.GetComponent<Bullet>();
        bulletComp.target = target.gameObject;
        bulletComp.damage = tower.CurrentDamage;
    }

    int SortByDistance(GameObject enemyA, GameObject enemyB)
    {
        float distanceToGoalA = enemyA.GetComponent<MoveEnemy>().DistanceToGoal();
        float distanceToGoalB = enemyB.GetComponent<MoveEnemy>().DistanceToGoal();
        return distanceToGoalA.CompareTo(distanceToGoalB);
    }

}

