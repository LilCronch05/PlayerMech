using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 30.0f, rotationSpeed = 100.0f, vInput, hInput, vInputMouse, hInputMouse;
    public GameObject body, legs, shoulders;
    Vector3 angles;

    //Jump variables
    public float jumpSpeed = 5000f;
    Rigidbody rb;
    bool canJump;

    //Added effects
    public AudioSource walkingSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            canJump = false;
        }
    }

    // Move and rotate player
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        hInputMouse = Input.GetAxis("Mouse X");
        vInputMouse = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.forward * vInput * movementSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * hInput * rotationSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            walkingSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            walkingSound.Stop();
        }
        
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(0f, jumpSpeed * Time.deltaTime, 0f);
        }
        
        //Body Rotation
        body.transform.Rotate(Vector3.up * hInputMouse * rotationSpeed * Time.deltaTime);
        angles = body.transform.localRotation.eulerAngles;
        if (angles.y > 90.0f && angles.y <= 180.0f)
        {
            body.transform.localRotation = Quaternion.Euler(angles.x, 90.0f, angles.z);
        }
        if (angles.y < 270.0f && angles.y >= 180.0f)
        {
            body.transform.localRotation = Quaternion.Euler(angles.x, 270.0f, angles.z);
        }

        //Shoulder Rotation
        shoulders.transform.Rotate(Vector3.right * vInputMouse * rotationSpeed * Time.deltaTime);
        angles = shoulders.transform.localRotation.eulerAngles;
        if (angles.x > 45.0f && angles.x <= 180.0f)
        {
            shoulders.transform.localRotation = Quaternion.Euler(45.0f, angles.y, angles.z);
        }
        if (angles.x < 315.0f && angles.x >= 180.0f)
        {
            shoulders.transform.localRotation = Quaternion.Euler(315.0f, angles.y, angles.z);
        }
    }
}
