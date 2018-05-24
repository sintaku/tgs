using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private PlayerSetting setting;
    private float moveSpeed;

	// Use this for initialization
	void Start () {
        setting = GetComponent<PlayerSetting>();
        moveSpeed = setting.moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += transform.right * horizontal * moveSpeed * Time.deltaTime;
	}

}
