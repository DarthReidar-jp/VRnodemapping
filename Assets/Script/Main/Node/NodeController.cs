using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
     //カーソルで選んだNodeを移動させる。
     void OnMouseDrag()
    {
        if (Input.GetKey("q") == false)
        {
             Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}
