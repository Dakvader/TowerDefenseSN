using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

    public double range;
    public double health;
    public double damage;

    void Update()
    {
        List <Enemy> nearbyEnemies = checkForEnemies();
    }

    List<Enemy> checkForEnemies ()
    {
        return null;
    }
}
