
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public CameraShaker camshake;
    public CharacterController controller;
    public TrailRenderer playerTrail;
    public Camera playerCam;
    public CapsuleCollider Body;
    public Transform bodyS;
    public Animator animator;
    public Transform cealingCheck;
    public Transform cealingCheck2;
    public Transform groundCheck;
    public Transform WallRunLeftCheck;
    public Transform WallRunRightCheck;
    public Transform WallrunCheck;
    public Vector3 velocity;

    public float groundDistance = 0.7f;
    public float cealingDistance = 0.4f;
    public float WallrunDist;
    public float WallrunAllow = 0.7f;
    public float wallrunDuration;
    public float wallrunMaxDur;
    public float speed = 14f;
    public float sprintSpeed = 0f;
    public float gravity = -39.24f;
    public float jumpForce;
    public float airTime;

    public int maxRegularJumpCount;
    public int jumpCount;
    public int maxJumpCount;
    public int extraJumpCount;

    public LayerMask groundMask;
    public LayerMask cealingMask;

    public bool isgrounded;
    public bool isCealing;
    public bool secondCealingCheck;
    public bool canJump;
    public bool isSprinting = false;
    public bool isRunning = false;
    public bool isCrouching = false;
    public bool isSliding = false;

    public bool wallrunLeft;
    public bool wallrunRight;
    public bool isWallrunning;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxRegularJumpCount = 2;
    }
    // Start is called before the first frame update


    // Update is called once per frame
    public void FixedUpdate()
    {
        
    }
    void Update()
    {
        
        Move();
        Jump();
        PlayerGravity();
        Crouch();
        Slide();
        Fixers();
        WallrunControl();
        SoundEffectsManager();
        SoundEffects();




    }



    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);
        

        if (Input.GetKey(KeyCode.LeftShift))
        {

            controller.Move(move * sprintSpeed * Time.deltaTime);
            isSprinting = true;
            
        }
        else
        {

            controller.Move(move * speed * Time.deltaTime);
            isSprinting = false;
            isRunning = true;
            
        }
    }

    public void PlayerGravity()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isgrounded)
        {

            isCealing = Physics.CheckSphere(cealingCheck.position, cealingDistance, cealingMask);

        }
        
        

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -3f;
            Invoke("AirtimeReset", .01f);
        }


    }
    public void AirtimeReset()
    {
        airTime = 0f;
    }
    public void Jump()
    {
        jumpCount = Mathf.Clamp(jumpCount, 0, 2);
        extraJumpCount = Mathf.Clamp(extraJumpCount, 0, 2);

        maxJumpCount = Mathf.Clamp(maxJumpCount, 0, 4);
        maxJumpCount = jumpCount + extraJumpCount;

        if (isgrounded || isWallrunning)
        {
            if(extraJumpCount > 0)
            {
                jumpCount = maxJumpCount;
            }
            else if(extraJumpCount <= 0)
            {
                jumpCount = maxRegularJumpCount;
            }
            
            speed = 20f;         
        }

        if (isSliding || isCrouching)
        {
            jumpForce = 13f;
        }else if (!isSliding ||!isCrouching)
        {
            jumpForce = 7f;
        }


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            Invoke("LowerJumpCount", 0.1f);
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
            AudioManager.audioinstance.PlayC("Jump");
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumpCount > 0 && jumpCount == 0)
        {
            Invoke("LowerExtraJumpCount", 0.1f);
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
            AudioManager.audioinstance.PlayC("Jump");

        }




    }
    public void LowerJumpCount()
    {
        jumpCount -= 1;
    }
    public void LowerExtraJumpCount()
    {
        extraJumpCount -= 1;
    }
    public void Crouch()
    {
         
        if (Input.GetKey(KeyCode.C) && isSprinting == false)
        {
            speed = 5f;
            sprintSpeed = 9f;
            isCrouching = true;                      
        }
        else
        {

            speed = 14f;
            
            isCrouching = false;
        }
        
    }
    public void Slide()
    {
        if (Input.GetKey(KeyCode.C) && isSprinting == true)
        {
          
            sprintSpeed -= Time.deltaTime * 10;
            isSliding = true;
        }
        else
        {
            
            isSliding = false;
        }
    }

    public void Fixers()
    {
        if (Input.GetKeyUp(KeyCode.C) && isgrounded)
        {
            velocity.y = Mathf.Sqrt(1 * -2 * gravity);          
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            playerCam.transform.localPosition = new Vector3(0f, 1.3f, .4f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerCam.transform.localPosition = new Vector3(0f, .4f, .4f);
        }

        //BodyModifiers
        controller.height = 3.8f;
        Body.radius = .68f;
        Body.height = 2.1f;
        bodyS.transform.localScale = new Vector3(1f, 2f, .8f);
        playerCam.transform.localPosition = new Vector3(0f, 1.3f, .4f);

        if (isSliding || isCrouching || isCealing)
        {
            
            controller.height = 1.6f;
            Body.height = 1f;
            playerCam.transform.localPosition = new Vector3(0f, .4f, .4f);
            bodyS.localScale = new Vector3(1f, 1f, .8f);
            speed = 5f;
            sprintSpeed = 9f;




        }
        //SprintControl
        playerCam.fieldOfView = Mathf.Clamp(playerCam.fieldOfView, 80, 100);
        sprintSpeed = Mathf.Clamp(sprintSpeed, 5f, 25f);

        if (isSprinting && sprintSpeed >= 21f)
        {
            playerCam.fieldOfView += Time.deltaTime * 10;
        }
         if (!isSprinting && !isSliding && !isCealing && !isCrouching)
        {
            sprintSpeed = 20f;
            playerCam.fieldOfView -= Time.deltaTime * 20;
        }
         if(isCrouching || isCealing || isSliding)
        {
            playerCam.fieldOfView -= Time.deltaTime * 20;

        }
        if (isSprinting)
        {

            sprintSpeed += Time.deltaTime * 2;
        }




        if(isCealing && isSprinting)
        {
            isSliding = true;
        }
        if (isSliding)
        {
            sprintSpeed = 22f;
        }

        //CameraShake

        airTime = Mathf.Clamp(airTime, 0f, 5f);

        if (!isgrounded)
        {
            airTime += Time.deltaTime;
        }
        if(airTime >= 0.4f && isgrounded)
        {
            AudioManager.audioinstance.Play("Land");
        }





    }



    public void WallrunControl()
    {
        wallrunLeft = Physics.CheckSphere(WallRunLeftCheck.position, WallrunDist, groundMask);
        wallrunRight = Physics.CheckSphere(WallRunRightCheck.position, WallrunDist, groundMask);
        isWallrunning = Physics.CheckSphere(WallrunCheck.position, WallrunAllow, groundMask);

        wallrunMaxDur = 1.2f;
        wallrunDuration = Mathf.Clamp(wallrunDuration, 0f, 2f);


        if (wallrunLeft && isWallrunning || wallrunRight && isWallrunning)
        {
            wallrunDuration -= Time.deltaTime;
        }
        if (!isWallrunning)
        {
            wallrunDuration = wallrunMaxDur;
        }

        
        if (isWallrunning && velocity.y < 0)
        {

            if (wallrunDuration >= 0)
            {
                velocity.y = -1f;
            }
        }
        

    }

   
        
    public void SoundEffectsManager()
    {
        

        if(AudioManager.audioinstance != null)
        {
            if (Input.GetKey(KeyCode.W) && isgrounded && !isSprinting && !isWallrunning && !isSliding || Input.GetKey(KeyCode.S) && isgrounded && !isSprinting && !isWallrunning && !isSliding || Input.GetKey(KeyCode.A) && isgrounded && !isSprinting && !isWallrunning && !isSliding || Input.GetKey(KeyCode.D) && isgrounded && !isSprinting && !isWallrunning && !isSliding)
            {

                AudioManager.audioinstance.Play("Walk");
            }
            else
            {
                AudioManager.audioinstance.Stop("Walk");
            }
            if (Input.GetKey(KeyCode.W) && isgrounded && isSprinting && !isWallrunning || Input.GetKey(KeyCode.S) && isgrounded && isSprinting && !isWallrunning || Input.GetKey(KeyCode.A) && isgrounded && isSprinting && !isWallrunning || Input.GetKey(KeyCode.D) && isgrounded && isSprinting && !isWallrunning || isWallrunning && !isgrounded)
            {
                AudioManager.audioinstance.Play("Run");
            }
            else
            {
                AudioManager.audioinstance.Stop("Run");
            }
            if (isSliding && isgrounded)
            {
                AudioManager.audioinstance.Play("Crawl");
            }
            else
            {
                AudioManager.audioinstance.Stop("Crawl");
            }
        }
        else
        {
            return;
        }

        


    }

    public void SoundEffects()
    {
        
    }


        
    

   


}
