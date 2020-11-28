using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject TeleportLocation;


    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet") || other.CompareTag("RicochetBullet"))
        {
            
            Destroy(gameObject);
        }

    }
    private void OnDestroy()
    {
        
        if (TeleportLocation != null && FindObjectOfType<PlayerMovement>() != null)
        {
            FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocation.transform.position;
            
        }

        FindObjectOfType<UIScript>().CheckpointNumber += 1;
    }


}
