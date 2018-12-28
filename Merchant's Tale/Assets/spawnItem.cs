using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{
  public GameObject Prefab;

  public void clicked(){
    Vector3 position = new Vector3(Random.Range(-9.0f, 2.0f),Random.Range(-5.0f, 1.0f),0);
    Instantiate(Prefab, position, Quaternion.identity);
  }
}
