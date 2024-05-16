using UnityEngine;
public class PlatformBehaviour : MonoBehaviour{
    private PlatformEffector2D effector2D;
    [SerializeField]
    private float timer;
    void Start(){
        getComponents();
    }
    void Update(){
        platformBehaviour();
    }
    void getComponents(){
        effector2D = GetComponent<PlatformEffector2D>();
    }
    void platformBehaviour(){
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)){
            timer = 0f;
            effector2D.rotationalOffset = 0f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            if(timer <= 0){
                timer = 0.5f;
                effector2D.rotationalOffset = 180f;
            }
            else{
                timer -= Time.deltaTime;
            }
        }
    }
}
