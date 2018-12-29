using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class editTotalItemsText : MonoBehaviour
{
  public Text textLol;
  // Update is called once per frame
  void Update()
  {
    textLol.text = "Total Items: " + gameManager.totalItems; 
  }
}
