using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class despawn : MonoBehaviour{
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
    Debug.Log("Pressed left click, casting ray.");
    CastRay();
    }
  }

  void CastRay() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100)) {
      Debug.DrawLine(ray.origin, hit.point);
    }
  }
}
