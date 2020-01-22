using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("General")]
    [Tooltip ("In ms^-1")][SerializeField] float speed = 45f;
    float xRange = 35f;
    float yRange = 20f;

    float xThrow, yThrow;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;

    [SerializeField] float positionYawFactor = -0.5f;
    [SerializeField] float controlRollFactor = -15f;

    bool isDead = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead){
            ProcessTranslation();
            ProcessRotation();
        }
        
    }


    void ProcessTranslation(){
        // X AXIS
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffsetThisFrame;

        rawNewXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        // Y AXIS
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime;

        float rawNewYPos = transform.localPosition.y + yOffsetThisFrame;

        rawNewYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(rawNewXPos, rawNewYPos ,transform.localPosition.z);
    }

    void ProcessRotation(){

        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnPlayerDeath(){
        isDead = true;
    }
}
