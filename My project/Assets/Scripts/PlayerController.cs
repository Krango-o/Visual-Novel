using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    public Animator anim;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
        theRB.rotation = Quaternion.Euler(new Vector3(moveInput.x, theRB.velocity.y, theRB.velocity.z));

        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);
        anim.SetFloat("moveSpeedX", moveInput.x );
        anim.SetFloat("moveSpeedY", moveInput.y );
      


        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        anim.SetBool("onGround", isGrounded);

        if(moveInput.x > 0.1)
        {
            anim.SetFloat("isFacingRight", 1 );
        }
        if(moveInput.x < -0.1)
        {
            anim.SetFloat("isFacingRight", -1 );
        }
    }
}
