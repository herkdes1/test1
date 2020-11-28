using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManagerInstance;

    private void Awake()
    {
        
        if(gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenuScript.mainmenuinstance.onLevel)
        {
            gameObject.SetActive(false);
        }
    }
}
