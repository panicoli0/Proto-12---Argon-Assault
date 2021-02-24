using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] int level;


    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<SplashScreen>().Length;

        //Condicion que protege que no se creen varios objetos entre scenes
        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(level);
    }
}
