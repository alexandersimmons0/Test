using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    private playerMovement player;
    public GameObject Enemy;
    public GameObject adjustedSpawn;
    private float fireRate = 10.0f;
    private float nextFire = 0.0f;
    private int health = 10;
    void Start(){
        player = GameObject.Find("Player").GetComponent<playerMovement>();
    }
    void Update(){
        if(Time.timeSinceLevelLoad>nextFire&&!player.gameOver&&!player.gameWin){
            nextFire = Time.timeSinceLevelLoad + fireRate;
            GameObject newEnemy = Instantiate(Enemy, adjustedSpawn.transform.position, adjustedSpawn.transform.rotation)as GameObject;
        }
        if(health<=0){
            player.spawnDes--;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="bullet"){
            health--;
        }
    }
}
