using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKMChildren : MonoBehaviour
{

  /*  GameObject Object;
    

    
    public bool gravityChecker;

    // Start is called before the first frame update
    private void Awake()
    {
        Object = this.gameObject;
        Object.AddComponent<BoxCollider>();
        gravityChecker = this.GetComponentInParent<BiggerCUBES>().childHasGravity;


        

        
        
    }

    void Start()
    {
        Object.GetComponent<Rigidbody>().useGravity = false;
        Object.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void ParentChecker()
    {


    }


    //Change the tags to your projectile's tag

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("RicochetBullet") || collision.collider.CompareTag("Bullet"))
        {
            Object.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.transform.parent = null;
            if (gravityChecker)
            {
                Object.GetComponent<Rigidbody>().useGravity = true;
            }
            
        }
    }

    */
}
