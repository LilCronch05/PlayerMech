using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : MonoBehaviour
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
        if (Input.GetKey(KeyCode.E))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletRange, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gunSound.Play();
        }
        else
        {
            gunSound.Stop();
        }
    }
}
