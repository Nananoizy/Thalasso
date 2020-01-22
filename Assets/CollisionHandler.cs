using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathExplosion;
    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other){
            StartDeathSequence();
    }

    private void StartDeathSequence(){
        deathExplosion.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("reloadScene", levelLoadDelay);
    }

    private void reloadScene(){
        SceneManager.LoadScene(1);
    }
}
