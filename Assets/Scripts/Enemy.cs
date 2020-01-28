using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Collider collider;
    [SerializeField] GameObject enemyDeathFX;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other){
        Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void AddNonTriggerBoxCollider(){
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }
}
