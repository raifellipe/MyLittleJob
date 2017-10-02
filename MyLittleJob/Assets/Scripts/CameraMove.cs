﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    [SerializeField]
    private float cameraSpeed = 0;

	// Update is called once per frame
	private void Update () {
        GetImput();
	}

    private void GetImput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
    }
}
