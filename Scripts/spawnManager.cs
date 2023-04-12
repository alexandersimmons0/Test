using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject yellowSpawn;
    public GameObject purpleSpawn;
    public GameObject redSpawn;
    private int i,k;
    private int j=1;
    public int maxX, minX, maxZ, minZ;
    private Vector3 pos;
    public int disBewteenSpawns;
    public List<Vector3> locations;
    
    private Vector3 genSpawn(){
        Vector3 pos;
        pos.x = UnityEngine.Random.Range(maxX, minX);
        pos.z = UnityEngine.Random.Range(maxZ, minZ);
        pos.y = -1;
        for(k=0;k<j;j++){
            if(locations.Contains(pos)&&(Math.Abs(locations[k].x)-Math.Abs(pos.x) >= disBewteenSpawns)&&(Math.Abs(locations[k].z)-Math.Abs(pos.z) >=disBewteenSpawns)){
            return genSpawn();
            }
        }
        locations.Add(pos);
        j++;
        return pos;
    }
    void Start(){
        locations.Add(new Vector3(0f,0f,0f));
        j=1;
        for(i=0;i<3;i++){
            pos = genSpawn();
            GameObject newYspawn = Instantiate(yellowSpawn, pos, this.transform.rotation);            
        }
        for(i=0;i<2;i++){
            pos = genSpawn();
            GameObject newPspawn = Instantiate(purpleSpawn, pos, this.transform.rotation);
        }
        pos = genSpawn();
        GameObject newRspawn = Instantiate(redSpawn, pos, this.transform.rotation);
    }
    void Update(){
        
    }
}
