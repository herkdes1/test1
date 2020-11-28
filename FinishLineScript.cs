using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject finishlinePanel;

    public bool LevelFinished;

    public void Start()
    {
        LevelFinished = false;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            LevelFinished = true;
            ScorePanel.SetActive(true);
            finishlinePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        

        
    }
}
