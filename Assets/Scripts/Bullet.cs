using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float fireForce = 10;
    public float fireDamage = 10;

void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

void Start()
    {
        _rigidBody.AddForce(transform.right * fireForce,ForceMode2D.Impulse);
    }

void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 7)
        {
            Enemy enemyScript = collider.gameObject.GetComponent<Enemy>(); 
            enemyScript.Die();
            FireDeath();
        }


        if(collider.gameObject.layer == 3)
        {
            FireDeath();
        }
    }

    void FireDeath()
    {
        Destroy(gameObject);
    }

}
