using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PauseMenuScript>().Restart();
        }
        
    }
}
