using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    private SphereCollider _col;
    private Rigidbody _rb;
    public GameObject Contact;
    void Start(){
        Debug.Log("Launched");
        _col = GetComponent<SphereCollider>();
        _rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag!="Player"&&collision.gameObject.tag!="bullet"){
            Destroy(this.gameObject);
        }
    }
}
