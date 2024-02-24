using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Camera followCam;
    [SerializeField]
    private Camera pauseCam;
    [SerializeField]
    private Transform spriteHolder;
    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private ParticleSystem runParticles;
    [SerializeField]
    private float jumpStrength = 10;
    [SerializeField]
    private float gravityStrength = 30;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float runMultiplier = 1.5f;
    [SerializeField]
    private float camCooldown = 1.0f;
    [SerializeField]
    private float camSpeed = 1.0f;

    //Movement
    private Animator anim;
    private CharacterController controller;
    private Vector3 hitNormal;
    private Vector2 moveInput;
    private Vector2 direction;

    //Jumping
    private float yVelocity = 0;
    private float terminalVelocity = -20;

    //Camera
    private bool camPaused;
    private int camPosition = 0;
    private float camTimer = 0;
    private Tween camTween;
    private Tween unpauseTween;
    private int[] camPositions = { 45, 135, 225, 315 };
    private Cinemachine.CinemachineOrbitalTransposer playerOrbitalCam;


    void Start()
    {
        playerOrbitalCam = GameManager.instance.PlayerCam.GetCinemachineComponent<Cinemachine.CinemachineOrbitalTransposer>();
        GameManager.instance.pauseGameEvent.AddListener(onPause);
        GameManager.instance.unpauseGameEvent.AddListener(onUnpause);
        Cinemachine.CinemachineCore.CameraUpdatedEvent.AddListener(CinemachineUpdate);
        controller = GetComponent<CharacterController>();
        anim = sprite.gameObject.GetComponent<Animator>();
    }

    void CinemachineUpdate(Cinemachine.CinemachineBrain brain)
    {
        //Make sprite constantly look at camera
        if (!camPaused)
        {
            spriteHolder.forward = Camera.main.transform.forward;
        }
    }


    void Update()
    {
        bool jumped = false;
        moveInput = Vector2.zero;
        if (GameManager.instance.CurrentGameState == GameState.OVERWORLD) {
            if (Input.GetButtonDown("Interact")) {
                GameObject interactableObject = GameManager.instance.GetClosestInteractable();
                if (interactableObject != null) {
                    interactableObject.GetComponent<Interactable>().Interact();
                }
            }
            //if (Input.GetButtonDown("Jump")) {
            //    jumped = true;
            //}
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }

        moveInput.Normalize();

        Vector3 move = Vector3.zero;

        if (controller.isGrounded) {
            yVelocity = -1f; //isGrounded is inconsistent unless setting the yVelocity to at least -1f every frame while on the ground.
        }
        else { //Gravity
            yVelocity -= gravityStrength * Time.deltaTime;
        }
        yVelocity = Mathf.Clamp(yVelocity, terminalVelocity, jumpStrength);

        //Slope
        bool isOnSlope = controller.isGrounded && (Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit);

        //Only allow player movement when not sliding on a slope
        if (!isOnSlope) {
            //create velocity vector
            Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            if (Camera.main.transform.rotation.y == 0)//checking weird quaternion forward issue
            {
                camForward.x += .001f;
            }
            float multiplier = 1;
            if (Input.GetButton("Sprint")) {
                multiplier = runMultiplier;
                if (!runParticles.isPlaying) {
                    runParticles.Play();
                }
            } else {
                runParticles.Stop();
            }
            move = (moveInput.y * camForward + moveInput.x * Camera.main.transform.right) * moveSpeed * multiplier;

            //Jump
            if (controller.isGrounded) {
                if (jumped) {
                    yVelocity = jumpStrength;
                }
            }
        } else {
            move.x = 2f * hitNormal.x;
            move.z = 2f * hitNormal.z;
        }

        move.y = yVelocity;

        anim.SetBool("onGround", controller.isGrounded);
        anim.SetFloat("moveSpeed", moveInput.magnitude);
        float offsetX = direction.x;
        float offsetZ = direction.y;
        //Save the last direction for when we stop
        if (Mathf.Abs(moveInput.x) > 0.01) {
            direction.x = moveInput.x;
            offsetX = 0;
        }
        if (Mathf.Abs(moveInput.y) > 0.01) {
            direction.y = moveInput.y;
            offsetZ = 0;
        }
        //Nudge character in last direction with magnitude if pressing cardinals
        anim.SetFloat("moveSpeedX", moveInput.x + offsetX);
        anim.SetFloat("moveSpeedY", moveInput.y + offsetZ);

        if (moveInput.x > 0.1) {
            anim.SetFloat("isFacingRight", 1);
        }
        if (moveInput.x < -0.1) {
            anim.SetFloat("isFacingRight", -1);
        }

        //set the velocity
        controller.Move(move * Time.deltaTime);

        if (!camPaused)
        {
            //RotateCamera();
        }
    }

    private void RotateCamera()
    {
        camTimer -= Time.deltaTime;
        if (camTimer > 0) { return; }
        int newCamPosition = camPosition;
        if (Input.GetButtonDown("RotateLeft"))
        {
            newCamPosition++;
            if(newCamPosition > camPositions.Length - 1)
            {
                newCamPosition = 0;
                playerOrbitalCam.m_XAxis.Value = -45;
            }
        }
        else if (Input.GetButtonDown("RotateRight"))
        {
            newCamPosition--;
            if(newCamPosition < 0)
            {
                newCamPosition = camPositions.Length - 1;
                playerOrbitalCam.m_XAxis.Value = 405;
            }
        }
        if(newCamPosition != camPosition)
        {
            camTimer = camCooldown;
            if (camTween != null)
            {
                camTween.Kill();
            }
            camTween = DOTween.To(() => playerOrbitalCam.m_XAxis.Value, x => playerOrbitalCam.m_XAxis.Value = x, camPositions[newCamPosition], camSpeed);
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

    public int GetCameraAxisPosition()
    {
        return camPositions[camPosition];
    }

    public Animator GetAnimator() {
        return anim;
    }
}
