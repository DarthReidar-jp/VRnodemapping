using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    //NodeUIスクリプトを格納する変数
    NodeUI _nodeUI;

    void Start(){
        //nodeUIの取得
        _nodeUI = GameObject.Find("NodeManager").GetComponent<NodeUI>();
    }

    //カーソルで選んだNodeを移動させる。
     void OnMouseDrag()
    {
        if (Input.GetKey("q") == false && _nodeUI.UIenable == false)
        {
            //このオブジェクトのポジションを代入
            Vector3 _objPos = Camera.main.WorldToScreenPoint(transform.position);
            //このマウスのポジションを代入
            Vector3 _mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _objPos.z);
            //このオブジェクトのポジションにマウスのポジションを代入
            transform.position = Camera.main.ScreenToWorldPoint(_mousePos);
        }
    }
}
