using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    //[SerializeField] int enemyPoint;
    ScoreBoard scoreBoard;
    public int scorePerHit = 12;



    private void Start()
    {
        AddNonTriggerEnemysCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerEnemysCollider()
    {
        Collider EnemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        EnemyBoxCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        
    }
}
