using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    private bool camPaused;
    private int camPosition = 0;
    [SerializeField]
    private float camCooldown = 1.0f;
    [SerializeField]
    private float camSpeed = 1.0f;
    private float camTimer = 0;
    private Tween camTween;
    private Tween unpauseTween;

    public Animator anim;
    [SerializeField]
    private Camera followCam;
    [SerializeField]
    private Camera pauseCam;
    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera virtualCam;
    private Cinemachine.CinemachineOrbitalTransposer orbitalCam;


    void Start()
    {
        orbitalCam = virtualCam.GetCinemachineComponent<Cinemachine.CinemachineOrbitalTransposer>();
        GameManager.instance.pauseGameEvent.AddListener(onPause);
        GameManager.instance.unpauseGameEvent.AddListener(onUnpause);
    }

    
    void Update()
    {
        if (GameManager.instance.characterDisabled) { return; }
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        //create velocity vector
        Vector3 m_CamForward = Vector3.Scale(followCam.transform.forward, new Vector3(1, 0, 1)).normalized;
        if (followCam.transform.rotation.y == 0)//checking weird quaternion forward issue
        {
            m_CamForward.x += .001f;
        }
        Vector3 m_Move = moveInput.y * m_CamForward + moveInput.x * followCam.transform.right;

        //set the velocity
        Vector3 newVelocity = Vector3.ClampMagnitude(m_Move, 1) * moveSpeed;

        theRB.velocity = newVelocity;

        //Make sprite constantly look at camera
        if (!camPaused)
        {
            sprite.transform.rotation = Quaternion.LookRotation(sprite.transform.position - followCam.transform.position);
        }

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

        if (!camPaused)
        {
            RotateCamera();
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

    private void RotateCamera()
    {
        camTimer -= Time.deltaTime;
        if (camTimer > 0) { return; }
        int newCamPosition = camPosition;
        int[] camPositions = { 45, 135, 225, 315 };
        if (Input.GetButtonDown("RotateLeft"))
        {
            newCamPosition++;
            if(newCamPosition > camPositions.Length - 1)
            {
                newCamPosition = 0;
                orbitalCam.m_XAxis.Value = -45;
            }
        }
        else if (Input.GetButtonDown("RotateRight"))
        {
            newCamPosition--;
            if(newCamPosition < 0)
            {
                newCamPosition = camPositions.Length - 1;
                orbitalCam.m_XAxis.Value = 405;
            }
        }
        if(newCamPosition != camPosition)
        {
            camTimer = camCooldown;
            if (camTween != null)
            {
                camTween.Kill();
            }
            camTween = DOTween.To(() => orbitalCam.m_XAxis.Value, x => orbitalCam.m_XAxis.Value = x, camPositions[newCamPosition], camSpeed);
            camPosition = newCamPosition;
        }
    }

    private void onPause()
    {
        camPaused = true;
        if (camTween != null)
        {
            camTween.Pause();
            if (unpauseTween != null)
            {
                unpauseTween.Kill();
            }
        }
    }
    private void onUnpause()
    {
        if (unpauseTween != null)
        {
            unpauseTween.Kill();
        }
        unpauseTween = DOVirtual.DelayedCall(0.5f, () =>
        {
            if (camTween != null)
            {
                camTween.Play();
            }
            camPaused = false;
        });
    }
}
