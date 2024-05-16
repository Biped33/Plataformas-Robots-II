using Unity.VisualScripting;
using UnityEngine;
public class PlayersManager : MonoBehaviour {
    [SerializeField]
    private int playersHealthPoints, deadZones = 6;
    [SerializeField]
    private float healthTimer;
    [SerializeField]
    private Transform respawnPoint;
    private SpriteRenderer sprite;
    public bool isAlive = true;
    public float DeathCounter = 0;
    public GameObject LoseMenu;
    public GameObject WinMenu;

    private Lives LivesCounter;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        LivesCounter = FindObjectOfType<Lives>();

    }
    private void Update()
    {
        noLivesBehabiour();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject.layer == deadZones) {
            if(healthTimer >= 0){
                healthTimer -= Time.deltaTime;
            }
            else if ( healthTimer <= 0){
                playersHealthPoints--;
                if(playersHealthPoints <= 0) {
                    isAlive = false;
                    DeathCounter++;
                    Debug.Log("death counter " + DeathCounter + "/5");
                    LivesCounter.RestLives();

                }
                healthTimer = 0.01f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish line")
        {
            Debug.Log("You´re Win");
            Time.timeScale = 0;
            WinMenu.SetActive(true);

            // Acceder al ScoreManager
          
        }
        if (collision.gameObject.tag == "EnemyCloud" || collision.gameObject.tag == "EnemyTentacle")
        {
            playersHealthPoints--;
            Debug.Log("HP :" + playersHealthPoints);
        }
    }

    public void restartPlayer() {
        gameObject.transform.position = respawnPoint.position;
        playersHealthPoints = 5;
        isAlive = true;
    }

    void noLivesBehabiour()
    {
        if (DeathCounter >= 3)
        {

            killPlayer();
        }
    }

    public void killPlayer()
    {
        Debug.Log("You´re Dead");
        LoseMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
