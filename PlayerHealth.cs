using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    //EnergyBar
    public Slider EnergyBar;
    public Gradient graident;

    public Image fill;

    public void SetMaxEnergy(float Energy)
    {
        EnergyBar.maxValue = Energy;
        EnergyBar.value = Energy;

        fill.color = graident.Evaluate(1f);
    }
    public void EneryBarController(float Energy)
    {
        EnergyBar.value = Energy;

        fill.color = graident.Evaluate(EnergyBar.normalizedValue);
    }


    /*//General
    public float MaxHealth;
    public float CurrentHealth;
    public float Damage;


    //LavaPit
    public float lavaTimer;
    public float maxLavatimer;

    public bool inlava;


    // Start is called before the first frame update
    void Start()
    {
        maxLavatimer = 1f;
        
        CurrentHealth = MaxHealth;
        inlava = false;
    }

    // Update is called once per frame
    void Update()
    {
        LavaTimerCalculator();
    }


    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            inlava = true;
            Damage = FindObjectOfType<LavaPit>().lavaDamage;

        }

    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Lava"))
        {
            inlava = true;
            Damage = FindObjectOfType<LavaPit>().lavaDamage;

        }
    }
    public void LavaTimerCalculator()
    {
        if (inlava)
        {
            lavaTimer -= Time.deltaTime;
            TakeDamage(Damage);
        }





        if (lavaTimer <= 0f)
        {
            TakeDamage(Damage);
            inlava = false;
            lavaTimer = maxLavatimer;
        }

    }*/
}
