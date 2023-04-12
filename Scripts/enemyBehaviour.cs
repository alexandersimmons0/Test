using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    private playerMovement player;
    private Vector3 playerPos;
    public float speed;
    public float health;
    void Start(){
        player = GameObject.Find("Player").GetComponent<playerMovement>();
    }

    void Update(){
        if(!player.gameOver){
            playerPos = player.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
        if(health<=0){
            player.enemyKill++;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="bullet"){
            health--;
        }
    }
}
