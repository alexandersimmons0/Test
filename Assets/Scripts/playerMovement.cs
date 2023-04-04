using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float hInput;
    private float vInput;
    public float normal;
    public float boost;
    private float speed;
    public int health = 10;
    public int spawnDes;
    public int enemyKill;
    public bool gameOver;
    public bool gameWin;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnDes<=0){
            gameWin=true;
        }
        if(health<=0){
            gameOver = true;
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = boost;
        }else{
            speed = normal;
        }
        hInput = Input.GetAxis("Horizontal") * speed;
        vInput = Input.GetAxis("Vertical") * speed; 
        _rb.MovePosition(transform.position + transform.forward * vInput * Time.deltaTime + transform.right * hInput * Time.fixedDeltaTime);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="enemy"){
            health--;
        }
    }
}
