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
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(level);
    }
}
