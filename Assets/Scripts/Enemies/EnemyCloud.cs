using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloud : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 1f;
    private Transform player;
    public float distance;
    public int EnemyCloudHealth = 2;

    private PointsManager pointsManagerScr;
    // Start is called before the first frame update
    void Start()
    {
        pointsManagerScr = FindObjectOfType<PointsManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }



    void Update()
    {
         if (player != null)
        {
            
            Vector3 direction = (player.transform.position - transform.position);

            
            if (direction != Vector3.zero)
            {
                direction.Normalize();
            }

           
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

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
            
        }
        if (EnemyCloudHealth <= 0)
        {
            pointsManagerScr.addPoints(5);
            Destroy(this.gameObject);
        }
    }
}
