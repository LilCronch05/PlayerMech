using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform BulletSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    float bulletRange = 50.0f;

    //Added effects
    public AudioSource gunSound;
    
    // Shoots the gun
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletRange, ForceMode.Impulse);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            gunSound.Play();
        }
        else
        {
            gunSound.Stop();
        }
    }
}
