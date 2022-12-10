using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 30.0f, rotationSpeed = 100.0f, vInput, hInput, vInputMouse, hInputMouse;
    public GameObject body, legs;
    Vector3 angles;

    //Jump variables
    public float jumpSpeed = 5000f;
    Rigidbody rb;
    bool canJump;

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
        transform.Translate(Vector3.right * hInput * movementSpeed * Time.deltaTime, Space.Self);
         //The legs will rotate to face the direction the player is moving
        legs.transform.position = transform.position;
        
        
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(0f, jumpSpeed * Time.deltaTime, 0f);
        }
        
        body.transform.Rotate(Vector3.up * hInputMouse * rotationSpeed * Time.deltaTime);
        angles = body.transform.localRotation.eulerAngles;
        if (angles.y > 35.0f && angles.y <= 180.0f)
        {
            body.transform.localRotation = Quaternion.Euler(angles.x, 35.0f, angles.z);
        }
        if (angles.y < 320.0f && angles.y >= 180.0f)
        {
            body.transform.localRotation = Quaternion.Euler(angles.x, 320.0f, angles.z);
        }
    }
}
