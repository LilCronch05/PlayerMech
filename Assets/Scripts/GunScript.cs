using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform BulletSpawn;
    public float fireRate, bulletSpeed;

    //This shoots the bullet
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, BulletSpawn.position, BulletSpawn.rotation);

            //Fire rate of the gun
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * (bulletSpeed * Time.deltaTime) * fireRate;
        }
    }
}
