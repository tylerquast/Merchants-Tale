using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDragable : MonoBehaviour {
    float offsetX;
    float offsetY;
	// Use this for initialization
	public void dragStart() {
        offsetX = Input.mousePosition.x - transform.position.x;
        offsetY = Input.mousePosition.y - transform.position.y;
    }
	
	// Update is called once per frame
	public void drag() {
       transform.position = new Vector3((Input.mousePosition.x - offsetX), (Input.mousePosition.y - offsetY), 0);
	}
}
