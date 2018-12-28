using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyItem : MonoBehaviour
{
  public GameObject item;
  
  public void destroyItemClick(){
      Destroy(this.item);
  }
}
