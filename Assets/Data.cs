using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public static int intValue;
    
	// Use this for initialization
	void Start () {
        Debug.Log("" + intValue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int returnInt()
    {
        return intValue;
    }
}
