using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementScript : NetworkBehaviour {

    // Use this for initialization
    public float move_speed;
    public float jump_speed;
	void Start () {
        move_speed = 6f;
        jump_speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
                if (isLocalPlayer)
                {
      transform.Translate(move_speed * Input.GetAxis("Horizontal") * Time.deltaTime, jump_speed * Input.GetAxis("Jump") * Time.deltaTime, move_speed * Input.GetAxis("Vertical") * Time.deltaTime);
                }
        
	}
}
