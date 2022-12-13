using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform BulletSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 1.0f;
    float bulletRange = 50.0f;
    
    // Shoots the gun
    void Update()
    {
        if (Input.GetKey("E"))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletRange, ForceMode.Impulse);
            }
        }
    }
}
