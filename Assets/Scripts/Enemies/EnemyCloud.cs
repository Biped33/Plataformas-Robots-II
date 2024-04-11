using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloud : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cloud;
    public float speed;
    public float distance;
    public int EnemyCloudHealth = 2;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCloudHealth = 2;  
    }

       
    
      void Update()
    {
        
        distance=Vector2.Distance(transform.position, Player.transform.position);
        Vector2 directions = Player.transform.position - transform.position;
       

        if (distance < 5)
        {
            transform.position=Vector2.MoveTowards(this.transform.position, Player.transform.position, speed*Time.deltaTime);
           // transform.rotation = Quaternion.Euler(Vector3.forward * angle);

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
            if (collision.gameObject.CompareTag("Player"))
            {

                EnemyCloudHealth--;
            }
        }
        if(EnemyCloudHealth <= 0)
        {
            Destroy(Cloud);
            //Add points
        }
    }
}
