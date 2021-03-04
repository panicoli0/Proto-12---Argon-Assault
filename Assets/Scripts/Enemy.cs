using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    //[SerializeField] int enemyPoint;
    ScoreBoard scoreBoard;
    public int scorePerHit = 12;
    [SerializeField] float enemyHealth = 4f;
    [SerializeField] float damagePerHit = 2f;

    //[SerializeField] TextMeshProUGUI enemyDestroyed;

    private void Start()
    {
        AddNonTriggerEnemysCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        //enemyDestroyed = FindObjectOfType<TextMeshProUGUI>();
    }

    private void AddNonTriggerEnemysCollider()
    {
        Collider EnemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        EnemyBoxCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        enemyHealth -= damagePerHit;
        if (enemyHealth <= 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        scoreBoard.ScoreHit(scorePerHit); //todo: cambiarlo a scorePerKill ?
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        //enemyDestroyed.text = "Enemy Destroyed: " + gameObject.name;
    }
}
