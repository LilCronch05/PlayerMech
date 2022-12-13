using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform bullet;
    float speed = 100.0f;

    private void Start()
    {
        bullet = GetComponent<Transform> ();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Target") //if the projectile hits the target
        { 
            GameObject Enemy = collision.gameObject;
            //EnemyScript enemyHealth = Enemy.GetComponent<EnemyScript> ();
            //enemyHealth.health  -= 10;

            Destroy(bullet.gameObject); //destroy the projectile
        }

        if(collision.gameObject.tag == "Bounds") //if the projectile hits the Arena
        {
            Destroy(bullet.gameObject); //destroy the projectile
        }
    }
}