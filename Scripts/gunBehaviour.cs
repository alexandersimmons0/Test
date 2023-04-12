using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawner;
    private playerMovement player;
    private float fireRate = 0.1f;
    private float nextFire = 0.0f;
    public int bulletCount = 30;
    public float bulletSpeed;
    public int bulletTotal = 150;
    void Start(){
        player = GameObject.Find("Player").GetComponent<playerMovement>();
    }

    void Update(){
        if(Input.GetMouseButton(0)&&bulletCount>0&&Time.timeSinceLevelLoad>nextFire&&!player.gameOver){
            nextFire = Time.timeSinceLevelLoad + fireRate;
            GameObject newBullet = Instantiate(bullet,
            bulletSpawner.transform.position,
            this.transform.rotation) as GameObject;
            Rigidbody bulletRB =
                newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            bulletCount--;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            if(bulletTotal>0){
                while(bulletCount<30&&bulletTotal>0){
                    bulletTotal--;
                    bulletCount++;
                }
            }
        }
    }
}
