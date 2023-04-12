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
    public int health;
    public int spawnDes;
    public int enemyKill;
    public bool gameOver;
    public bool gameWin;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyUp(KeyCode.Tab)&&Time.timeScale == 1f){
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }else if(Input.GetKeyUp(KeyCode.Tab)){
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void FixedUpdate()
    {
        if(spawnDes<=0){
            Cursor.lockState = CursorLockMode.None;
            gameWin=true;
        }
        if(health<=0){
            Cursor.lockState = CursorLockMode.None;
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
        if(collision.gameObject.tag=="enemyTypeN"){
            health-=5;
        }else if(collision.gameObject.tag=="enemyTypeS"){
            health--;
        }else if(collision.gameObject.tag=="enemyTypeH"){
            health-=15;
        }
    }
}
