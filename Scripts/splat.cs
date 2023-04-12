using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splat : MonoBehaviour
{
    private float OnScreenDelay = 2f;
    public GameObject spot;
    void Start(){
        Destroy(spot, OnScreenDelay);
    }
}
