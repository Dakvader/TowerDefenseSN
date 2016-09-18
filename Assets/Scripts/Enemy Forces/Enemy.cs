using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public double health;
    public double movementSpeed;

    void damageTaken(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {

    }
}
