using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
  public GameObject panel;

  public void openPanel(){
      if(panel != null){
        bool isActive = panel.activeSelf;
        panel.SetActive(!isActive);
      }
  }
}
