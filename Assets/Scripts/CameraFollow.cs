using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform PlayerTransform;

    private Vector3 _cameraOffset;
    private bool isPlayer;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

	// Use this for initialization
	void Start () {
        // isPlayer=false;
         _cameraOffset = transform.position - PlayerTransform.position;	
	}
	
	// LateUpdate is called after Update
	void Update () {
        if (!isPlayer)
        {
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            isPlayer=!isPlayer;
        }
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer)
            transform.LookAt(PlayerTransform);

	}
}
