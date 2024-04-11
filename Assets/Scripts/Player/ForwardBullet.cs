using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBullet : MonoBehaviour
{
    public float speed = 33f;
    float timerDestroy = 0f;


    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.right * speed * Time.deltaTime);


        if (timerDestroy >= 1f)
        {
            Destroy(this.gameObject);
        }

        timerDestroy += Time.deltaTime;
    }
}
