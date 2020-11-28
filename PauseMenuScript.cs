using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static PauseMenuScript PMInstance;
    private void Awake()
    {
        if(PMInstance == null)
        {
            PMInstance = this;
        }
        else
        {
            return;
        }
    }

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    public bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;   
    }

    // Update is called once per frame
    void Update()
    {
        PauseTheGame();
    }

    public void PauseTheGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<TimeScript>().Timeunfreezer();
        FindObjectOfType<TimeScript>().UnZawardo();
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if(SettingsMenuScript.SettingsInstance != null)
        {
            if (SettingsMenuScript.SettingsInstance.gameObject.transform.parent == null)
            {
                SettingsMenuScript.SettingsInstance.gameObject.SetActive(false);
            }
        }
        else
        {
            return;
        }

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        FindObjectOfType<MouseLook>().mouseSense = 300f;
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<TimeScript>().UnZawardo();
        gameIsPaused = false;
        GameManager.gameManagerInstance.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SettingsMenuOpen();
        Invoke("SettingsMenuClose", 0.03f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<TimeScript>().UnZawardo();
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void NextLevel()
    {
        SettingsMenuOpen();
        Invoke("SettingsMenuClose", 0.03f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<TimeScript>().UnZawardo();
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SettingsMenuOpen()
    {
        if(SettingsMenuScript.SettingsInstance != null)
        {
            SettingsMenuScript.SettingsInstance.gameObject.transform.parent = null;
            SettingsMenuScript.SettingsInstance.gameObject.SetActive(true);
            pauseMenuUI.SetActive(false);
        }


    }
    
    public void SettingsMenuClose()
    {
        if (PauseMenuScript.PMInstance != null)
        {
            //SettingsMenuScript.SettingsInstance.gameObject.transform.parent = GameManager.gameManagerInstance.transform;
            SettingsMenuScript.SettingsInstance.gameObject.transform.SetParent(GameManager.gameManagerInstance.transform);
            SettingsMenuScript.SettingsInstance.gameObject.SetActive(false);
            PauseMenuScript.PMInstance.pauseMenuUI.SetActive(true);

        }
        else
        {
            return;
        }
    }
}
