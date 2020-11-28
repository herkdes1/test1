using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerChallanger : MonoBehaviour
{

    public int stageNumber;

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject stage5;
    // Start is called before the first frame update
    void Start()
    {
        stageNumber = 4;
    }

    // Update is called once per frame
    void Update()
    {
        stageNumber = FindObjectOfType<UIScript>().CheckpointNumber;
        
    }
    private void FixedUpdate()
    {
        StageManager();
    }

    public void StageManager()
    {
        if(stageNumber == 0)
        {
            stage1.SetActive(true);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        else if (stageNumber == 1)
        {
            stage1.SetActive(true);
            stage2.SetActive(true);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        else if (stageNumber == 2)
        {
            stage1.SetActive(true);
            stage2.SetActive(true);
            stage3.SetActive(true);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        else if (stageNumber == 3)
        {
            stage1.SetActive(true);
            stage2.SetActive(true);
            stage3.SetActive(true);
            stage4.SetActive(true);
            stage5.SetActive(false);
        }
        else if (stageNumber == 4)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(true);
        }
    }
}
