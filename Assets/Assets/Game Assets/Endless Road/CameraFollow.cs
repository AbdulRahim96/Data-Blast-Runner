﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;


	public static float smoothSpeedx = 0.01f;
	public static float smoothSpeedy = 0.03f;
	public Vector3 offset;
	float x, y;
    private void Start()
    {
		Quaternion rot = new Quaternion(0, 0, 0, 0);
		transform.rotation = rot;
		
		target = GameObject.FindGameObjectWithTag("Player").transform;
		offset = transform.position - target.position;
		
		smoothSpeedx = PlayerPrefs.GetFloat("x", 0.1f);
		smoothSpeedy = PlayerPrefs.GetFloat("y", 0.3f);
	}
    void Update()
	{
		x = transform.position.x;
		y = transform.position.y;
		x = Mathf.Lerp(x, target.position.x, smoothSpeedx);
		y = Mathf.Lerp(y, target.position.y, smoothSpeedy);
		Vector3 desiredPosition = new Vector3(x, y, offset.z + target.position.z);
		transform.position = desiredPosition;
		offset = Vector3.Lerp(offset, (Vector3.zero), 0.1f);

		//transform.LookAt(target);
	}

}