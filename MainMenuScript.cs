using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
public class MainMenuScript : MonoBehaviour
{

    public static MainMenuScript mainmenuinstance;

    private void Awake()
    {
        if(mainmenuinstance == null)
        {
            
            mainmenuinstance = this;
            onLevel = false;
        }else
        {
            Destroy(this);
            return;
        }

    }
    public Animator animator;

    public GameObject ChaptersSegment;
    public GameObject MainMenuSegment;
    public GameObject SettingsSegment;


    public Volume MainmenuFX;
    ColorAdjustments colorAdjLayer;

    public bool onLevel;

    public bool Chaptersbool;
    public bool Mgrader;
    public bool settings;
    


    // Update is called once per frame
    void Update()
    {
       
            MenuManagment();
            MainMenuEffects();


        
       
 
        

    }

    void MainMenuEffects()
    {
        MainmenuFX.profile.TryGet<ColorAdjustments>(out colorAdjLayer);
        if (!Mgrader)
        {
            colorAdjLayer.hueShift.value += Time.deltaTime * 60;
        }
        if (Mgrader)
        {
            colorAdjLayer.hueShift.value -= Time.deltaTime * 60;
        }
        if (colorAdjLayer.hueShift.value >= 120)
        {
            Mgrader = true;
        }
        if (colorAdjLayer.hueShift.value <= -120)
        {
            Mgrader = false;
        }

    }

    public void StarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.gameManagerInstance.gameObject.SetActive(false);


    }

    public void MenuManagment()
    {
        if (Chaptersbool)
        {
            ChaptersSegment.SetActive(true);
            MainMenuSegment.SetActive(false);

        }

        if (settings)
        {
            SettingsMenuScript.SettingsInstance.gameObject.SetActive(true);
            MainMenuSegment.SetActive(false);
        }
        else if (!settings && !Chaptersbool)
        {
            SettingsMenuScript.SettingsInstance.gameObject.SetActive(false);
            ChaptersSegment.SetActive(false);
            MainMenuSegment.SetActive(true);
        }





    }

    public void DisableMainMenu()
    {
        MainMenuSegment.SetActive(false);
    }
    public void EnableMainMenu()
    {
        MainMenuSegment.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        animator.SetBool("Chapters", false);

        if(MainMenuScript.mainmenuinstance != null)
        {
            MainMenuScript.mainmenuinstance.settings = false;
            MainMenuScript.mainmenuinstance.Chaptersbool = false;
        }
        else
        {
            return;
        }


    }

    public void SettingsMenuB()
    {
        settings = true;

    }
    public void Chapters()
    {
        animator.SetBool("Chapters", true);
        Chaptersbool = true;
    }
    public void Chapter1()
    {
        SceneManager.LoadScene("TutorialLevel");
        GameManager.gameManagerInstance.gameObject.SetActive(false);
    }
    public void Chapter2()
    {
        SceneManager.LoadScene("Tutorial2");
        GameManager.gameManagerInstance.gameObject.SetActive(false);
    }
    public void Chapter3()
    {
        SceneManager.LoadScene("Tutorial3");
        GameManager.gameManagerInstance.gameObject.SetActive(false);
    }
    public void Chapter4()
    {
        SceneManager.LoadScene("ChallangeLevel1");
        GameManager.gameManagerInstance.gameObject.SetActive(false);
    }
    public void Chapter5()
    {
        SceneManager.LoadScene("ChallangeLevel2");
        GameManager.gameManagerInstance.gameObject.SetActive(false);
    }
    public void Chapter6()
    {
        SceneManager.LoadScene("ChallangeLevel3");
        GameManager.gameManagerInstance.gameObject.SetActive(false);
    }
}
