using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class splashScreenLoad : MonoBehaviour
{
    void Start()
    {
        Invoke("loadNextLevel", 6f);
    }

    private void loadNextLevel(){

        int mainIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(mainIndex + 1);
    }
}
