using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCubeRed : MonoBehaviour
{



    //General Purpose
    public float MaxHealth;
    public float CurrentHealth;
    public float Damage;
    public float ThrowDamage;

    //Explosions
    public float ExpRadius;
    public float ExpDamage;
    public float ExpForce;
    public GameObject destroyedVersion;


    public void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void Update()
    {
        Destroy1();


        
    }

    public void Destroy1()
    {
        if (CurrentHealth <= 0)
        {
            destroyedVersion.transform.localScale = gameObject.transform.localScale;
            Explode();
            Destroy(gameObject);
            Instantiate(destroyedVersion, transform.position, transform.rotation);
        }
    }
    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;

    }
    public void TakeThrowDamage(float ThrowDamage)
    {
        CurrentHealth -= ThrowDamage;

    }
    private void OnTriggerEnter(Collider other)
    {

        ThrowDamage = FindObjectOfType<GunScript>().throwDamage;
        if (other.CompareTag("RicochetBullet"))
        {
            TakeDamage(200);

        }
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(120);

        }
        if (other.CompareTag("Pistol"))
        {
            TakeThrowDamage(ThrowDamage);

        }
    }
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExpRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(ExpForce, transform.position, ExpRadius);
            }
            /*ExplodingCube ExpCube = nearbyObject.GetComponent<ExplodingCube>();
            if (ExpCube != null)
            {
                ExpCube.TakeDamage(ExpDamage);
            }*/
        }


    }
    private void OnDestroy()
    {
        EneryBack();
        JumpBack();
        if (AudioManager.audioinstance != null)
        {
            AudioManager.audioinstance.PlayC("Expo1");

        }
        else
        {
            return;
        }

        if (FindObjectOfType<UIScript>() != null)
        {

            FindObjectOfType<UIScript>().killScore += 50f;
        }
        else
        {
            return;
        }


    }
    public void EneryBack()
    {
        if(FindObjectOfType<PlayerAbilityManager>() != null)
        {
            FindObjectOfType<PlayerAbilityManager>().EnergyGain(5);
        }
        else
        {
            return;
        }
        
    }
    public void JumpBack()
    {


        if (PlayerMovement.instance != null)
        {
            PlayerMovement.instance.extraJumpCount += 1;
        }
        else
        {
            return;
        }

    }

}
