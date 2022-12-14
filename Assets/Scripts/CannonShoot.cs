using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonShoot : MonoBehaviour
{
    public GameObject cannonBall;
    public int cannonBallCount = 5;
    public Transform cannonBallSpawn;
    public float shotForce = 1500f;
    public ParticleSystem muzzleFlash;
    public AudioSource shotSound;
    public TextMeshProUGUI remainingRocketsText;

    //Setting up recoil animation
    //public Animation recoilAnim;
    //public bool isRecoiling = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingRocketsText.text = ("Rockets: " + cannonBallCount);
        
        // If the left mouse button is clicked, shoot the cannon ball
        if (Input.GetKeyDown(KeyCode.Q) && cannonBallCount > 0)
        {
            //Play particle effect
            muzzleFlash.Play();
            
            //Play sound effect
            shotSound.Play();

            //Play recoil animation  
            //recoilAnim.Play();    

            Shoot();
            cannonBallCount--;
        }
        
        if (cannonBallCount == 0)
        {
            remainingRocketsText.text = ("Rockets: 0");
        }
    }

    void Shoot()
    {
        // Instantiate the cannon ball
        GameObject cannonBallCount = Instantiate(cannonBall, cannonBallSpawn.position, cannonBallSpawn.rotation);

        // Add force to the cannon ball
        cannonBallCount.GetComponent<Rigidbody>().AddForce(cannonBallSpawn.forward * shotForce);
    }
}
