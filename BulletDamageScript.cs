using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageScript : MonoBehaviour
{//WORK İN PROGRESS
    public static BulletDamageScript bulletInstance;


    public Rigidbody bulletRB;

    public GameObject ImpEffect;

    public float maxBounce = 4f;
    public float bounceCounter;
    public float bulletDamage;

    public bool gonnaBounce;

    public bool isEssential;


    private void Awake()
    {

        if (bulletInstance == null)
        {
         bulletInstance = this;
        }
        else
        {
            return;
        }
            
    }
    public void Start()
    {
        gonnaBounce = false;
        
        bounceCounter = maxBounce;

        bounceCounter = Mathf.Clamp(bounceCounter, 0f, 4f);
        
        Destroy(this.gameObject, 10f);

       /* if (AudioManager.instanceAudio == null)
        {
            return;
        }
        else
        {
            AudioManager.instanceAudio.Play("Shoot1");
        }*/


    }

    public void Update()
    {
        Bouncer();

        if (gonnaBounce)
        {
            BulletHomeing();
        }

    }
    private void OnTriggerEnter(Collider other)
    {


        bulletRB.useGravity = true;
        GameObject sparks = Instantiate(ImpEffect, transform.position, transform.rotation);
        Destroy(sparks, 1f);
        bounceCounter -= 1f;
        gonnaBounce = true;

        if (other.CompareTag("Boxes"))
        {
            bounceCounter -= 2f;
            
        }


    }
    private void OnCollisionEnter(Collision collision)
    {


        //Instantiate(ImpEffect, transform.position, transform.rotation);
    }
    public void Bouncer()
    {
        if(bounceCounter <= 0)
        {
            Destroy(this.gameObject, 0.001f);
        }
        
    }

    public void BulletHomeing()
    {

        float distancetoClosestEnemy = 300f;
        EnemyFinder closestEnemy = null;
        EnemyFinder[] allEnemies = GameObject.FindObjectsOfType<EnemyFinder>();

        if(allEnemies != null)
        {
            foreach (EnemyFinder currentEnemy in allEnemies)
            {
                float distancetoEnemy = (currentEnemy.transform.position - bulletRB.transform.position).sqrMagnitude;
                if (distancetoEnemy < distancetoClosestEnemy)
                {
                    distancetoClosestEnemy = distancetoEnemy;
                    closestEnemy = currentEnemy;

                }
            }
            if(closestEnemy != null)
            {
                Vector3 bulletDirection = closestEnemy.transform.position - bulletRB.transform.position;
                bulletDirection.Normalize();
                Vector3 rotationAmount = Vector3.Cross(transform.position, bulletDirection);
                bulletRB.angularVelocity = rotationAmount * 50f;
                bulletRB.velocity = bulletDirection * 300f;
            }
            else
            {
                return;
            }

        }
        else
        {
            return;
        }



    }






    //UnsuedCode
    /*public void BulletDamageCalculator()
    {
        if(FindObjectOfType<GunScript>().whichBullet == true)
        {
            bulletDamage = 50;
        }
        else
        {
            bulletDamage = 120;
        }
        
    }*/
    /*if(bulletRB.velocity.magnitude <= 100f)
        {
            bulletDamage = 60;
        }
        if (bulletRB.velocity.magnitude > 100f && bulletRB.velocity.magnitude <= 130f)
        {
            bulletDamage = 80;
        }
        if (bulletRB.velocity.magnitude > 130f && bulletRB.velocity.magnitude <= 170f)
        {
            bulletDamage = 120;
        }
        if (bulletRB.velocity.magnitude > 170f && bulletRB.velocity.magnitude <= 220f)
        {
            bulletDamage = 150;
        }*/

    /*    public float bulletSpeed = 170f;
    public float bulletSpeed2 = 200f;
    public float bulletSpeed3 = 240f;
    public float bulletSpeed4 = 290f;*/
}
