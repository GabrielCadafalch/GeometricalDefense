using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    [HideInInspector]    
    public float startHealth = 100f;
    private float health;
    public int moneyGain = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    // The next target location of the enemy
    private Transform target;
    private int wavepointIndex = 0;


    // At the start the target will be the first waypoint, that is in front of the enemy spawn
    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += moneyGain;        
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}