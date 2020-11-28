using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public float killScore;

    public GameObject scoreBoard;
    public GameObject TotalScoreC;

    public float timeHasPassed;

    public float totalX;
    public float totalY;
    public float totalZ;
    public float totalScore;

    public int CheckpointNumber;

    public int JumpCountUINumber;

    public float sceneNumber;

    public Image JumpIcon;

    public Text Ammo;
     
    public TextMeshProUGUI ammo2;
    public TextMeshProUGUI TotalScore;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI TimeS;
    public TextMeshProUGUI CheckpointText;
    public TextMeshProUGUI jumpCountText; 

    public bool timer;

    private void Start()
    {
        timeHasPassed = 0f;
        CheckpointNumber = 0;
        scoreBoard.SetActive(false);
    }
    void Update()
    {
        

        ScoreBoard();
        RemainingAmmo();
        KillScore();
        TimeScore();
        TotalScoreCalculator();
        Jumper();
        CheckpointChecker();


    }
    public void RemainingAmmo()
    {
        ammo2.text = FindObjectOfType<GunScript>().currentAmmo.ToString("0/15");
    }

    public void KillScore()
    {
        Score.text = killScore.ToString("Score: 0");
    }
    public void Jumper()
    {
        JumpCountUINumber = Mathf.Clamp(JumpCountUINumber, 0, 4);
        JumpCountUINumber = PlayerMovement.instance.maxJumpCount;

        jumpCountText.text = JumpCountUINumber.ToString("0 X");
        
        if(PlayerMovement.instance != null)
        {
            if(JumpCountUINumber > 0)
            {
                
                    JumpIcon.enabled = true;
            }else
            {
                    JumpIcon.enabled = false;
            }
            
        }
        else
        {
            return;
        }



        /*        
         *{
            var IconColor = JumpIcon.color;
            IconColor.a = 0f;
            JumpIcon.color = IconColor;
          }*/
    }



    public void CheckpointChecker()
    {
        CheckpointNumber = Mathf.Clamp(CheckpointNumber, 0, 4);

        if(CheckpointText != null)
        {
            CheckpointText.text = CheckpointNumber.ToString("Checkpoints: 0/4");
        }
        else
        {
            return;

        }
        
    }
    public void ScoreBoard()
    {


        if (FindObjectOfType<FinishLineScript>() != null)
        {
            if (FindObjectOfType<FinishLineScript>().LevelFinished == false)
            {
                if (Input.GetKey(KeyCode.Tab))
                {
                    scoreBoard.SetActive(true);
                }
                else
                {
                    scoreBoard.SetActive(false);
                }
            }
        }
        else
        {
            return;
        }


    }
    public void TimeScore()
    {
        
         timeHasPassed += Time.deltaTime;
        
        

        TimeS.text = timeHasPassed.ToString("Time has passed: 0");
    }
    public void TotalScoreCalculator()
    {
        if (FindObjectOfType<FinishLineScript>() != null)
        {

         if (FindObjectOfType<FinishLineScript>().LevelFinished == true)
         {
            TotalScoreC.SetActive(true);
         }
            else
            {
            TotalScoreC.SetActive(false);
            }
        }
        else
        {
            return;
        }


        TotalScore.text = totalScore.ToString("Total Score: 0");

        if(sceneNumber == 1)
        {
            if (timeHasPassed <= 25f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 2.5f;
                totalZ = killScore * 3f;
                totalScore = (totalZ + totalX) - totalY;
            }
            if (timeHasPassed <= 45f && timeHasPassed > 25f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 7.5f;
                totalZ = killScore * 1.5f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 4;
            }
            if (timeHasPassed > 45f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 9.5f;
                totalZ = killScore * 1.7f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 2;
            }
            //totalScore = (totalZ + totalX) - totalY;
        }
        if (sceneNumber == 2)
        {
            if (timeHasPassed <= 20f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 2.5f;
                totalZ = killScore * 3f;
                totalScore = (totalZ + totalX) - totalY;
            }
            if (timeHasPassed <= 30f && timeHasPassed > 20f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 7.5f;
                totalZ = killScore * 1.5f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 4;
            }
            if (timeHasPassed > 30f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 9.5f;
                totalZ = killScore * 1.7f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 2;
            }
        }
        if (sceneNumber == 3)
        {
            if (timeHasPassed <= 65f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 2.5f;
                totalZ = killScore * 3f;
                totalScore = (totalZ + totalX) - totalY;
            }
            if (timeHasPassed <= 95f && timeHasPassed > 65f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 7.5f;
                totalZ = killScore * 1.5f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 4;
            }
            if (timeHasPassed > 95f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 9.5f;
                totalZ = killScore * 1.7f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 2;
            }

        }
        if (sceneNumber == 4)
        {
            if (timeHasPassed <= 125f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 2.5f;
                totalZ = killScore * 3f;
                totalScore = (totalZ + totalX) - totalY;
            }
            if (timeHasPassed <= 150f && timeHasPassed > 125f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 7.5f;
                totalZ = killScore * 1.5f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 4;
            }
            if (timeHasPassed > 150f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 9.5f;
                totalZ = killScore * 1.7f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 2;
            }

        }
        if (sceneNumber == 5)
        {
            if (timeHasPassed <= 125f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 2.5f;
                totalZ = killScore * 3f;
                totalScore = (totalZ + totalX) - totalY;
            }
            if (timeHasPassed <= 150f && timeHasPassed > 125f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 7.5f;
                totalZ = killScore * 1.5f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 4;
            }
            if (timeHasPassed > 150f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 9.5f;
                totalZ = killScore * 1.7f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 2;
            }

        }
        if (sceneNumber == 6)
        {
            if (timeHasPassed <= 125f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 2.5f;
                totalZ = killScore * 3f;
                totalScore = (totalZ + totalX) - totalY;
            }
            if (timeHasPassed <= 150f && timeHasPassed > 125f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 7.5f;
                totalZ = killScore * 1.5f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 4;
            }
            if (timeHasPassed > 150f)
            {
                totalX = timeHasPassed * 10;
                totalY = timeHasPassed * 9.5f;
                totalZ = killScore * 1.7f;
                totalScore = ((totalZ + totalX) - totalY) - killScore / 2;
            }

        }

    }

}
