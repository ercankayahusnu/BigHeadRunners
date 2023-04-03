using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject StartMenuPanel;
    public GameObject SucessPanel;

    private void Awake()
    {
            if(instance != null && instance != this)
            {
                     Destroy(instance);
            }
            else
            {
                instance = this;

            }

    }
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void StartButtonTapped()
    {

        StartMenuPanel.gameObject.SetActive(false);
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerScript = playerGO.GetComponent<PlayerController>();
        playerScript.GameStarted();
    }
    public void NextLevelButtonTapped()
    {
        SucessPanel.gameObject.SetActive(false);
        LevelController.instance.NextLevel();
    }

    public void ShowSucessMenu()
    {
        SucessPanel.gameObject.SetActive(true);
    }
}
