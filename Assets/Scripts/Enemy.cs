using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Collider collider;
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] int pointsPerHit = 12;

    [SerializeField] int hits = 3;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other){
        
        hits--;

        if (hits <= 0){
            KillEnemy();
        }
    }

    void AddNonTriggerBoxCollider(){
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    void KillEnemy(){

        Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        scoreBoard.ScoreHit(pointsPerHit);
        Destroy(gameObject);

    }
}
