using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{
  public GameObject Prefab;
  public GameObject success;
  public GameObject failure;
  int i = 0;


  public void clicked(){
    int rand = Random.Range(1,3);
    Debug.Log("Random number is " + rand);
    //Success
    if(rand == 1){
      StartCoroutine(successRender(2));
    }
    else{
      StartCoroutine(failureDisplay(2));
    }
  }

  IEnumerator failureDisplay(float secToWait){
    Debug.Log("Start");
    failure.SetActive(true);
    yield return new WaitForSeconds(secToWait);
    Debug.Log("end");
    failure.SetActive(false);
  }
  IEnumerator successRender(float secToWait){
    Debug.Log("Start");
    success.SetActive(true);
    yield return new WaitForSeconds(secToWait);
    Debug.Log("end");
    success.SetActive(false);
    Vector3 position = new Vector3(Random.Range(-9.0f, 2.0f),Random.Range(-5.0f, 1.0f),0);
    Prefab.name = i.ToString();
    i++;
    Instantiate(Prefab, position, Quaternion.identity);
  }
}
