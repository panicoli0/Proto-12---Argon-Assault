using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Tooltip ("m/s en frame")][SerializeField] float xSpeed = 4f;
    float horizontalThrow, verticalThrow;

    [Header("General")]
    [SerializeField] float pitchX;
    [SerializeField] float yawY;
    [SerializeField] float rawZ;

    [Header("Current Position")]
    float xPos;
    float yPos;

    [SerializeField] bool isControlEnabled = true;

    [SerializeField] GameObject[] gunsFX;


    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProccessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
        
    }

    void ProcessFiring()
    {
        
        //si presionas la spaceBar que dispare
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ActivateGuns();
        } else
        {
            DeActivateGuns();
        }
    }
   
    private void ActivateGuns()
    {
        foreach(GameObject gun in gunsFX)
        {
            gun.SetActive(true);        }
    }

    private void DeActivateGuns()
    {
        foreach(GameObject gun in gunsFX)
        {
            gun.SetActive(false);
        }
    }

    public void StartDeadSecuence() //Escucha CollisionHandler.cs
    {
        print("CONTROLES FREEZADOS");
        isControlEnabled = false;
        
        //Reset pos lo maneja CollisionHandler.cs

    }

    private void ProccessTranslation()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //captura el float horizontal
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical"); // captura el float vertical

        float xOffset = horizontalThrow * xSpeed * Time.deltaTime; //cuanto se mueve en m/s la nave sobre x
        float yOffset = verticalThrow * xSpeed * Time.deltaTime; // cuanto se mueve en m/s la nave sobre y

        float rawNewXPos = xOffset + transform.localPosition.x; // tranforma la poss  de la nave en el eje X
        float rawNewYPos = yOffset + transform.localPosition.y; // tranforma la poss  de la nave en el eje y


        xPos = Mathf.Clamp(rawNewXPos, -5, 5);
        yPos = Mathf.Clamp(rawNewYPos, -3, 3);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z); // Mueve la nave
    }

    private void ProcessRotation()
    {

        float updatePitchX = pitchX * verticalThrow + transform.localRotation.x;
        float updateYawY = yawY * horizontalThrow + transform.localRotation.y;
        float updateRawZ = rawZ * horizontalThrow + transform.localRotation.z;

        transform.localRotation = Quaternion.Euler(updatePitchX, updateYawY, updateRawZ);
        
    }

    //void ShootSecuence()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        foreach(GameObject gun in gunsFX)
    //        {
    //            gun.SetActive(true);
    //        }       
    //    } else
    //    {
    //        foreach (GameObject gun in gunsFX)
    //        {
    //            gun.SetActive(false);
    //        }
    //    }
    //} //Segunda opcion
}
