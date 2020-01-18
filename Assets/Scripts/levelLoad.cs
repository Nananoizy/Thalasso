using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        Invoke("loadNextLevel", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadNextLevel(){

        int mainIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(mainIndex + 1);
    }
}
