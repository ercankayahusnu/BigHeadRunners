using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    private int currentLevel;
    private int maxLevel;

    
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        maxLevel = 2;
        DontDestroyOnLoad(gameObject);
        GetLevel();


    }
    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("levelKey", 1);
        LoadLevel();
    }
    private void LoadLevel()
    {
        string strLevel = "Level" + currentLevel;
        SceneManager.LoadScene(strLevel);
    }
    public void NextLevel()
    {
        currentLevel++;
        
        if(currentLevel > maxLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("levelKey", currentLevel);
        LoadLevel();
    }
}
