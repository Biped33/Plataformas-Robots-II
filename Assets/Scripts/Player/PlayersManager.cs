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
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
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
                }
                healthTimer = 0.01f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Finish line"){
            Debug.Log("You´re Win");
        }
    }
    public void restartPlayer() {
        gameObject.transform.position = respawnPoint.position;
        playersHealthPoints = 5;
        isAlive = true;
    }
}
