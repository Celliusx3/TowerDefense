using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    public int damage;
    public GameObject target;
    public int goldOnKill = 50;
    public float slowSpeed = 0f;
    public int damageOverTime = 0;
    public bool isMultiElectric = false;
    private GameManager gameManager;

    void Start() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() 
    {
        if (target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);

            if (gameObject.transform.position.Equals(target.transform.position)) {
                Enemy enemy = target.GetComponent<Enemy>();
                enemy.CurrentHealth -= damage;
                enemy.ApplyPoison(damageOverTime);
                enemy.CurrentMoveSpeed = Mathf.Max(enemy.CurrentMoveSpeed - slowSpeed * enemy.CurrentMoveSpeed, 0.1f);
                // 4
                if (enemy.CurrentHealth <= 0)
                {
                    Destroy(target);
                    gameManager.Gold += goldOnKill;
                }
                Destroy(gameObject);
            }
        } else {
            Destroy(gameObject);
        }
    }

    // abstract protected void OnEnemyDamaged(Enemy enemy);
    // abstract protected void OnEnemyKilled(Enemy enemy);

}
