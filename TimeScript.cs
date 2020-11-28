using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class TimeScript : MonoBehaviour
{
    public static TimeScript timeinstance;

    public GameObject SlowmoFX;


    public GameObject generalVFX;
    Bloom GeneralBloom;




    public bool timefrozen;



    private void Awake()
    {
        if(timeinstance == null)
        {
            timeinstance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        TimeControl();

        
    }

    public void TimeControl()
    {
        if(FindObjectOfType<PauseMenuScript>() != null)
        {

            if (FindObjectOfType<PauseMenuScript>().gameIsPaused == false)
            {
                if (Input.GetKeyDown(KeyCode.Q) && !timefrozen || Input.GetKeyDown(KeyCode.Mouse4) && !timefrozen)
                {
                    if (FindObjectOfType<PlayerAbilityManager>().currentEnergy > 0)
                    {
                        FindObjectOfType<MouseLook>().speedo = true;
                        Zawardo();
                        Invoke("Timeboolcontroller", 0.01f);
                    }

                }
                if (Input.GetKeyDown(KeyCode.Q) && timefrozen || Input.GetKeyDown(KeyCode.Mouse4) && timefrozen || FindObjectOfType<PlayerAbilityManager>().currentEnergy <= 0)
                {
                    FindObjectOfType<MouseLook>().speedo = false;
                    UnZawardo();
                    Invoke("Timeunfreezer", 0.01f);
                }
            }
        }
        else
        {
            return;
        }



    }


    public void Zawardo()
    {
        
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;


        
        SlowmoFX.SetActive(true);
        
    }
    public void UnZawardo()
    {
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        SlowmoFX.SetActive(false);

    }
    public void Timeboolcontroller()
    {
        timefrozen = true;
    }
    public void Timeunfreezer()
    {
        timefrozen = false;
    }


}
