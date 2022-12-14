using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float effectTime = 20f;
    public GameObject explosion;
    public float minY = -20f;
    public AudioSource shotSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StatusCheck();
    }

    void StatusCheck()
    {
        effectTime -= Time.deltaTime;
        
        if (effectTime <= 0)
        {
            Destroy(gameObject);
            explosion.SetActive(false);
        }

        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    void Destroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            shotSound.Play();

            GameObject Enemy = collision.gameObject;
            EnemyScript enemyHealth = Enemy.GetComponent<EnemyScript> ();
            enemyHealth.health  -= 100;

            Destroy();
        }

        if (collision.gameObject.layer == 3)
        {
            shotSound.Play();
            Destroy();
        }
    }
}
