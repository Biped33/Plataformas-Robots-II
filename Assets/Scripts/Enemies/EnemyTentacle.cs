using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTentacle : MonoBehaviour
{
    public GameObject enemyCloud;
    private PointsManager pointsManagerScr;

    void Start()
    {
        // Obtener referencia al componente PointsManager
        pointsManagerScr = FindObjectOfType<PointsManager>();
    }

    private void Update()
    {
        // Verificar si el objeto "Enemy Cloud" ha sido destruido
        if (enemyCloud == null)
        {
            // Agregar puntos usando el componente PointsManager
            if (pointsManagerScr != null)
            {
                pointsManagerScr.addPoints(3);
            // Destruir este GameObject
            Destroy(this.gameObject);
            }

        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {


        //if (EnemyCloudHealth > 0)
        //{
        //    if (collision.gameObject.CompareTag("Lazer"))
        //    {
        //        EnemyCloudHealth--;
        //        Destroy(collision.gameObject);
        //    }
        //    if (collision.gameObject.CompareTag("Player"))
        //    {

        //        EnemyCloudHealth--;
        //    }
        //}
        //if (EnemyCloudHealth <= 0)
        //{
        //    Destroy(this.gameObject);
        //    //Add points
        //}
    }
}

