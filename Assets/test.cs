using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    float i = 1;
    public float max = 100;
    float x, y, z;

    void Start () {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }
	
	void FixedUpdate () {
        extendObj();
    }
    

    void extendObj()
    {
        if (i <= max){
            this.transform.localScale = new Vector3(100, i, 100);
            this.transform.position = new Vector3(x, y + i / 2, z);
            i++;
        }
    }

    public void setNum(int max)
    {
        this.max = max;
    }
}
