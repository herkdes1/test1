using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : MonoBehaviour
{
    public static RicochetBullet ricochetInstance;

    private Rigidbody bulletRB;

    public GameObject ImpEffect;

    public float maxBounceCounter = 3f;
    public float bounceCounter;


    public bool Ricochet;
    // Start is called before the first frame update

    private void Awake()
    {
        if(ricochetInstance = null)
        {
            ricochetInstance = this;
        }
        bulletRB = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {

        bounceCounter = maxBounceCounter;
        Ricochet = false;
    }

    // Update is called once per frame
    void Update()
    {

        BulletHomeing();
        BounceFixer();
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject sparks = Instantiate(ImpEffect, transform.position, transform.rotation);
        Destroy(sparks, 1f);
        bounceCounter -= 1f;
    }


    public void BulletHomeing()
    {
        if (Ricochet)
        {

            float distancetoClosestEnemy = Mathf.Infinity;
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


    }

    public void BounceFixer()
    {
        if(bounceCounter <= 0f)
        {
            Destroy(this.gameObject, 0.1f);
        }
        
    }




    /*
    public void BulletHomeing()
    {
        ricTimer -= Time.deltaTime;
        float distancetoClosestEnemy = Mathf.Infinity;
        EnemyFinder closestEnemy = null;
        EnemyFinder[] allEnemies = GameObject.FindObjectsOfType<EnemyFinder>();

        foreach (EnemyFinder currentEnemy in allEnemies)
        {
            float distancetoEnemy = (currentEnemy.transform.position - bulletRB.transform.position).sqrMagnitude;
            if (distancetoEnemy < distancetoClosestEnemy)
            {
                distancetoClosestEnemy = distancetoEnemy;
                closestEnemy = currentEnemy;

            }
        }
        Vector3 bulletDirection = closestEnemy.transform.position - bulletRB.transform.position;
        bulletDirection.Normalize();
        Vector3 rotationAmount = Vector3.Cross(transform.position, bulletDirection);
        bulletRB.angularVelocity = rotationAmount * 500f;
        bulletRB.velocity = bulletDirection * 300f;
    }*/
}
