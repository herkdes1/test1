using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuScript : MonoBehaviour
{
    public static SettingsMenuScript SettingsInstance;


    private void Awake()
    {
        if (SettingsInstance == null)
        {
            SettingsInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }
    
    
    private void Update()
    {
        if (FindObjectOfType<MouseLook>() != null)
        {

            FindObjectOfType<MouseLook>().mouseSense = MouseSetting;
        }
        else
        {

            return;
        }
    }

    public float MouseSetting;

    public void Start()
    {


        Invoke("Disablethis", .001f);
    }


    public void MouseSense(float value)
    {
        MouseSetting = value;


    }

    public void Enablethis()
    {
        gameObject.SetActive(true);
    }
    public void Disablethis()
    {
        gameObject.SetActive(false);
    }
    public void back2()
    {
        if(PauseMenuScript.PMInstance != null)
        {
            //SettingsMenuScript.SettingsInstance.gameObject.transform.parent = GameManager.gameManagerInstance.transform;
            SettingsMenuScript.SettingsInstance.gameObject.transform.SetParent(GameManager.gameManagerInstance.transform);
            gameObject.SetActive(false);
            PauseMenuScript.PMInstance.pauseMenuUI.SetActive(true);
            
        }
        else
        {
            return;
        }
    }
}
