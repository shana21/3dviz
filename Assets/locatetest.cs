using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locatetest : MonoBehaviour {
    GameObject obj;
    public double longitude=35.285160+0f, latitude=139.674364+0f;

    private Vector3 direction;
    private Vector3 moveDirection = new Vector3();

    // Use this for initialization
    void Start () {
        obj = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float veclat = (float)(latitude - 139)*2000;
        float veclong = (float)(longitude - 35)*2000;

        
        transform.position=Vector3.MoveTowards(new Vector3(0,0,0),new Vector3(veclat,0, veclong),5000f);
        //obj.transform.position = vec;
    }
}
