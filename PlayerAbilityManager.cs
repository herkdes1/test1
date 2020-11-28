using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{

    public static PlayerAbilityManager AbilityInstance;

    private void Awake()
    {
        if (AbilityInstance = null)
        {
            AbilityInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        EnergyBar.SetMaxEnergy(maxEnergy);

    }

    // Update is called once per frame
    void Update()
    {
        AbilityUsage();
        //Ricochet();
    }

    //Energy 
    public float maxEnergy = 100;
    public float currentEnergy;

    public float maxCounter;
    public float Counter;

    public PlayerHealth EnergyBar;


    public void EnergySpent(float Cost)
    {
        currentEnergy -= Cost;

        EnergyBar.EneryBarController(currentEnergy);
    }
    public void EnergyGain(float Back) 
    {
        currentEnergy += Back;
        EnergyBar.EneryBarController(currentEnergy);

    }

    public void AbilityUsage()
    {
        maxEnergy = Mathf.Clamp(maxEnergy, 0, 100);
        currentEnergy = Mathf.Clamp(currentEnergy, 0, 100);
        Ricochet();
        TimeFreeze();
        AirJumpGain();
    }

    //Ricochet Ability
    public void Ricochet()
    {
        RicochetBullet bullet = GameObject.FindObjectOfType<RicochetBullet>();
        if (Input.GetKeyDown(KeyCode.F) && currentEnergy >= 40f && bullet != null)
        {
            EnergySpent(40);
            FindObjectOfType<RicochetBullet>().Ricochet = true;

        }
    }

   //TimeFrozen

    public void TimeFreeze()
    {
        if (FindObjectOfType<MouseLook>().speedo)
        {
            EnergySpent(.05f);
        }
    }

    //AirJump


    public bool canGainJump;
    public float Airjump;
    public void AirJumpGain()
    {
        Airjump = Mathf.Clamp(Airjump, 0f, 2f);
        if(FindObjectOfType<PlayerMovement>() != null)
        {
            
        


        }
        else
        {
            return;
            
        }        


    }





    
}
