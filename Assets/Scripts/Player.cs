using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip ("In ms^-1")][SerializeField] float speed = 35f;
    float xRange = 23.5f;
    float yRange = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // X AXIS
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffsetThisFrame;

        rawNewXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        // Y AXIS
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime;

        float rawNewYPos = transform.localPosition.y + yOffsetThisFrame;

        rawNewYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(rawNewXPos, rawNewYPos ,transform.localPosition.z);
    }
}
