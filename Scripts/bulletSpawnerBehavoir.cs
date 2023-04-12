using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawnerBehavoir : MonoBehaviour
{
    public GameObject cubeCollect;
    public int spawnerType;//0 for bullets, 1 for health
    private gunBehaviour gun;
    private playerMovement player;
    private bool collected;
    void Start(){
        cubeCollect.SetActive(true);
        gun = GameObject.Find("gun??").GetComponent<gunBehaviour>();
        player = GameObject.Find("Player").GetComponent<playerMovement>();
    }
    IEnumerator ResetCube(){
        yield return new WaitForSeconds(10);
        collected = false;
        cubeCollect.SetActive(true);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag=="Player"&&!collected){
            cubeCollect.SetActive(false);
            if(spawnerType==0){
                gun.bulletTotal += 60;
            }
            else if(spawnerType==1){
                player.health += 5;
            }
            collected = true;
            StartCoroutine(ResetCube());
        }
    }
}
