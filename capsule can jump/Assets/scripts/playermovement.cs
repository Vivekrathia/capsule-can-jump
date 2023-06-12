using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float movementspeed = 5f; //SearializedField - created a button inside engine which allows you to adjust movement speed in realtime.
    [SerializeField] float jumpforce = 5f;     //SearializedField - created a button inside engine which allows you to adjust jump speed in realtime.
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementspeed, rb.velocity.y, verticalInput * movementspeed);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump();
        }   
        
    }

    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);
        jumpSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemyhead"))
        {
            Destroy(collision.transform.parent.gameObject);
            jump();
        }
    }
    
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundcheck.position, .1f, ground);
    }
}
