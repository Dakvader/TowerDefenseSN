using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

    public float health;
    public float maxDamage = 40;
    public float minDamage = 20;

    //This approach should be good for a wide range of values
    public float attackDelay = 100f;
    public float attackSpeed = 100f;

    float nextDamageEvent = 0f;

    List<GameObject> nearbyEnemies = new List<GameObject>();

    void Update()
    {
        
        if (nearbyEnemies.Count != 0)
        {
            if (Time.time >= nextDamageEvent)
            {
                nextDamageEvent = Time.time + (attackDelay / attackSpeed);

                int index = Random.Range(0, nearbyEnemies.Count);
                GameObject enemy = nearbyEnemies[index];
                if(enemy == null || enemy.GetComponent<Enemy>().ApplyDamage(Random.Range(minDamage, maxDamage)))
                {
                    nearbyEnemies.Remove(enemy);
                    Debug.Log("Enemies nearby for " + this.name + ": " + nearbyEnemies.Count);
                }

                if (enemy != null)
                {
                    Debug.Log("Enemy " + enemy.name + " hit by " + this.name +  ". Health remaining :" + enemy.GetComponent<Enemy>().health);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Add(other.gameObject);
            Debug.Log("Enemies nearby for " + this.name + ": " + nearbyEnemies.Count);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Remove(other.gameObject);
            Debug.Log("Enemies nearby for " + this.name + ": " + nearbyEnemies.Count);
        }
    }
}
