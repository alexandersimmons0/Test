using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class screenOverlay : MonoBehaviour
{
    public Text health;
    public Text spawn;
    public Text bullets;
    public GameObject losing;
    public GameObject win;
    public Text enemyKillCount;
    public GameObject endingPanel;
    private playerMovement player;
    private gunBehaviour bullet;
    void Start(){
        player = GameObject.Find("Player").GetComponent<playerMovement>();
        bullet = GameObject.Find("gun??").GetComponent<gunBehaviour>();
        endingPanel.SetActive(false);
    }
    void Update()
    {
        health.text = "Health: " + player.health;
        spawn.text = "" + player.spawnDes + " Targets Remaining";
        bullets.text = "" + bullet.bulletCount+" | "+bullet.bulletTotal;
        if(player.gameOver||player.gameWin){
            endingPanel.SetActive(true);
            enemyKillCount.text=""+ player.enemyKill+" Enemies Killed";
            if(!player.gameOver&&player.gameWin){
                losing.SetActive(false);
                win.SetActive(true);
            }else if(!player.gameWin&&player.gameOver){
                losing.SetActive(true);
                win.SetActive(false);
            }
        }
    }
}
