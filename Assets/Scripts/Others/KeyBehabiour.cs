using UnityEngine;

public class KeyBehabiour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerBehaviour playerBehaviour = collision.GetComponent<PlayerBehaviour>();
            if (playerBehaviour != null)
            {
                playerBehaviour.hasKey = true;
                transform.SetParent(collision.transform);
            }
        }
        else if (collision.CompareTag("Door") && transform.parent != null && transform.parent.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destruir la puerta
            Destroy(gameObject); // Destruir la llave
        }
    }
}