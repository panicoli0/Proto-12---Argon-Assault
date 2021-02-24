using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float LoadLevelDelay = 1f;
    [SerializeField] GameObject explosionFX;


    void OnTriggerEnter(Collider other)
    {
        StartDeadSecuence(other);
    }

    private void StartDeadSecuence(Collider other)
    {
        print("Player Entro en zona de colision con: " + other);
        //le manda msj a PlayerController.cs
        SendMessage("StartDeadSecuence");
        // explosion part y vuelve a empezar
        explosionFX.SetActive(true);
        Invoke("LoadFirstLevel", LoadLevelDelay);

    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
