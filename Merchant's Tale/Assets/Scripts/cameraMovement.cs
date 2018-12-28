using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    //public Transform MainCamera;
    public Vector3 newPosition;
    public float newScale;
    private Camera newCam;
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
            newPosition.x = newPosition.x - (float)1;
        }
        if (Input.GetKey("d"))
        {
            //right
            newPosition.x = newPosition.x + (float)1;

        }
        if (Input.GetKey("w"))
        {
            //up
            newPosition.y = newPosition.y + (float)1;

        }
        if (Input.GetKey("s"))
        {
            //down
            newPosition.y = newPosition.y - (float)1;

        }
        //scroll
        newScale = newScale - 100 * Input.GetAxis("Mouse ScrollWheel");

        transform.position = newPosition;
        newCam.orthographicSize = newScale;
    }
}
