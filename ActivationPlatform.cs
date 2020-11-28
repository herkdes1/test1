using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPlatform : MonoBehaviour
{
    public GameObject trialObjects;
    // Start is called before the first frame update
    void Start()
    {
        trialObjects.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trialObjects.SetActive(true);
        }
    }
}
