using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    //public Transform MainCamera;
    public Vector3 newPosition;
    public float newScale;
    private Camera newCam;
    public float direcitonalSpeed = (float).01;
    public float zoomSpeed = (float)1.0;
	// Use this for initialization
	void Start () {
        
        newPosition = transform.position;
        newCam = Camera.main;
        newScale = newCam.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            //left
            newPosition.x = newPosition.x - direcitonalSpeed;
        }
        if (Input.GetKey("d"))
        {
            //right
            newPosition.x = newPosition.x + direcitonalSpeed;

        }
        if (Input.GetKey("w"))
        {
            //up
            newPosition.y = newPosition.y + direcitonalSpeed;

        }
        if (Input.GetKey("s"))
        {
            //down
            newPosition.y = newPosition.y - direcitonalSpeed;

        }
        //scroll
        newScale = newScale - zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        transform.position = newPosition;
        newCam.orthographicSize = newScale;
    }
}
