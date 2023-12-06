using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level1(){
        SceneManager.LoadScene(1);
    }

    public void Level2(){
        SceneManager.LoadScene(2);
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
    public void GameOver(){
        SceneManager.LoadScene(3);
    }

    public void CurrentScene(){
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
}
