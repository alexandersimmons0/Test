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
    public GameObject sightLine;
    public Text enemyKillCount;
    public GameObject endingPanel;
    public GameObject fadeIn;
    private playerMovement player;
    private gunBehaviour bullet;
    void Start(){
        player = GameObject.Find("Player").GetComponent<playerMovement>();
        bullet = GameObject.Find("gun??").GetComponent<gunBehaviour>();
        endingPanel.SetActive(false);
        sightLine.SetActive(true);
        fadeIn.SetActive(true);
    }
    void Update()
    {
        health.text = "Health: " + player.health;
        spawn.text = "" + player.spawnDes + " Targets Remaining";
        bullets.text = "" + bullet.bulletCount+" | "+bullet.bulletTotal;
        if(player.gameOver||player.gameWin){
            fadeIn.SetActive(false);
            sightLine.SetActive(false);
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
