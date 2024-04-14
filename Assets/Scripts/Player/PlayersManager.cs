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
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
                }
                healthTimer = 0.01f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Finish line"){
            Debug.Log("You´re Win");
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
        if (DeathCounter >= 5)
        {
            Debug.Log("You´re Dead");
            this.gameObject.SetActive(false);
        }
    }
}
