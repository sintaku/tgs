using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollOut : MonoBehaviour {

    public GameObject bollPre;
    private float timeOut;
    public float BollOutTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeOut += Time.deltaTime;

        if (timeOut>=BollOutTime)
        {
            Instantiate(bollPre, transform.position, Quaternion.identity);

            timeOut = 0.0f;

            
        }
		
	}
}
