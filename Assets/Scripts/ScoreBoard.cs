using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int totalScore;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();
        scoreText.text = totalScore.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        totalScore = scorePerHit + totalScore;
        scoreText.text = totalScore.ToString();
    }
}
