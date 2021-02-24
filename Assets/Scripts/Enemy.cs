using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;

    private void OnParticleCollision(GameObject other)
    {
        print("Le pegast a enemy" + other.gameObject);

        //si le pegaste a un other gameObject
            //destroy
        if(other.gameObject)
        {
            explosionFX.SetActive(true);
            Invoke("EnemyDeath", 0.4f);
        }
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
