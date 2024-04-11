using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTentacle : MonoBehaviour
{

    public GameObject Tentacle;
    public int EnemyCloudHealth = 1;
    void Start()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (EnemyCloudHealth > 0)
        {
            if (collision.gameObject.CompareTag("Lazer"))
            {
                EnemyCloudHealth--;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("Player"))
            {

                EnemyCloudHealth--;
            }
        }
        if (EnemyCloudHealth <= 0)
        {
            Destroy(Tentacle);
            //Add points
        }
    }
}
