using UnityEngine;
public class GameManager : MonoBehaviour {
    public PlayersManager player;
    void Update() {
        playersDead();
    }
    private void playersDead() {
        if (!player.isAlive) {
            player.restartPlayer();
        }
    }
}
