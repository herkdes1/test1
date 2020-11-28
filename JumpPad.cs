using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Transform playerCheck;

    public float playerDistance = .5f;
    public float extraJumpForce = 12f;

    public bool playerison;

    public LayerMask playerMask;



    void Update()
    {
        playerison = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask);

        if (playerison)
        {
            ExtraJump();
            //FindObjectOfType<TimeScript>().UnZawardo();
        }
    }

    public void ExtraJump()
    {
        PlayerMovement.instance.velocity.y = Mathf.Sqrt(extraJumpForce * -2 * PlayerMovement.instance.gravity);
        PlayerMovement.instance.jumpCount = 2;
    }
}


