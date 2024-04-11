using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    
    public GameObject BulletPrefab;
    bool shoot = false;


    private void Update()
    {
        if (shoot == true)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bulletPrefab = Instantiate(BulletPrefab, transform.position, transform.rotation);
                Destroy(BulletPrefab, .6f);
                shoot = false;
                

            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            shoot = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyCloud"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyTentacle"))
        {
            //ScoreScript.AddPoints(-10);

            Destroy(gameObject);
        }
    }

}

