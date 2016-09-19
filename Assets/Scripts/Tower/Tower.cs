using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

    public float range;
    public float health;
    public float damage = 20;

    List<GameObject> nearbyEnemies = new List<GameObject>();

    void Update()
    {
        if (nearbyEnemies.Count != 0)
        {
            int index = Random.Range(0, nearbyEnemies.Count);
            GameObject enemy = nearbyEnemies[index];
            enemy.GetComponent<Enemy>().damageTaken(damage);

            Debug.Log("Enemy " + enemy.name + " hit. Health remaining :" + enemy.GetComponent<Enemy>().health);
        }
    }

    List<Enemy> checkForEnemies ()
    {
        return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Add(other.gameObject);
            Debug.Log(nearbyEnemies.Count);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Remove(other.gameObject);
            Debug.Log(nearbyEnemies.Count);
        }
    }
}
