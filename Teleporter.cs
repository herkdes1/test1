using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    
    public GameObject TeleportLocation;
    
    /*public GameObject TeleportLocation2;
    public GameObject TeleportLocation3;
    public GameObject TeleportLocation4;
    public GameObject TeleportLocation5;
    */


    int teleported;

    // Start is called before the first frame update
    void Start()
    {
        teleported = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TeleporterLocator();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation.transform.position;

        }
        /* Invoke("TeleporterAdder", 0.05f);
         if (other.CompareTag("Player") && teleported == 0)
         {

             FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation.transform.position;

         }
         else if (other.CompareTag("Player") && teleported == 1)
         {
             FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation2.transform.position;

         }
         else if (other.CompareTag("Player") && teleported == 2)
         {
             FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation3.transform.position;

         }
         else if (other.CompareTag("Player") && teleported == 3)
         {
             FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation4.transform.position;

         }
         else if (other.CompareTag("Player") && teleported == 4)
         {
             FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation5.transform.position;

         }*/

    }

    public void TeleporterLocator()
    {
        teleported = Mathf.Clamp(teleported, 0, 10);

    }
    public void TeleporterAdder()
    {
        teleported += 1;
    }
}
