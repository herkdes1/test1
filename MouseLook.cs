using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSense;

    public bool isWallrunning;
    public bool wallrunRight;
    public bool wallrunLeft;
    public bool isGrounded;
    public bool speedo;

    public Transform playerBody;

    float xRotation = 0f;
    float wallrunSide = 0f;

    // Start is called before the first frame update
    void Start()
    {
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SettingsMenuScript.SettingsInstance.gameObject.SetActive(true);
        if(SettingsMenuScript.SettingsInstance != null)
        {
            mouseSense = SettingsMenuScript.SettingsInstance.MouseSetting;
        }
        else
        {
            return;
        }
        speedo = false;
        Invoke("DisableSettingsMenu", .01f);
    }

    // Update is called once per frame
    void Update()
    {
        MouseSenseCalculator();
        MouseMovement();
        Wallruncheck();




    }
    public void MouseMovement()
    {
        if (speedo)
        {
            float mouseX = Input.GetAxis("Mouse X") * (mouseSense * 3.3f) * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * (mouseSense * 3.3f) * Time.deltaTime;


            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, wallrunSide);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else if (!speedo)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;


            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, wallrunSide);
            playerBody.Rotate(Vector3.up * mouseX);

        }

    }
    public void MouseSenseCalculator()
    {
        mouseSense = Mathf.Clamp(mouseSense, 100, 1000);
 

    }

    public void Wallruncheck()
    {
        isWallrunning = FindObjectOfType<PlayerMovement>().isWallrunning;
        wallrunLeft = FindObjectOfType<PlayerMovement>().wallrunLeft;
        wallrunRight = FindObjectOfType<PlayerMovement>().wallrunRight;
        isGrounded = FindObjectOfType<PlayerMovement>().isgrounded;

        if (isWallrunning && wallrunLeft)
        {
            wallrunSide = -10f;
           
        }
        if (isWallrunning && wallrunRight)
        {
            wallrunSide = 10f;
           
        }

        if (!isWallrunning)
        {
            wallrunSide = 0f;
        }
        if (isWallrunning && isGrounded)
        {
            wallrunSide = 0f;
        }
    }

    public void DisableSettingsMenu()
    {
        SettingsMenuScript.SettingsInstance.gameObject.SetActive(false);
    }
}
