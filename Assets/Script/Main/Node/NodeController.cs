using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    //_付きの変数はプライベート、無しの変数はパブリック

    //NodeUIスクリプトを格納する変数
    NodeUI _nodeUI;

    //自身のスクリーン座標を代入する変数
    Vector3 _nodePos;
    //マウスの座標を代入する変数
    Vector3 _mousePos;

    void Start()
    {
        //nodeUIの取得
        _nodeUI = GameObject.Find("NodeManager").GetComponent<NodeUI>();
    }

    //マウスで選んだNodeを移動させる。
    void OnMouseDrag()
    {
        //もしqが押されていないかつ、UIが非表示ならばNodeの移動を許可する。
        if (Input.GetKey(KeyCode.LeftShift) == false && _nodeUI.isUIenable == false)
        {
            //選択されたNodeのスクリーン座標のポジションを変数に代入
            _nodePos = Camera.main.WorldToScreenPoint(transform.position);
            //このマウスのポジションを代入
            _mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _nodePos.z);
            //このオブジェクトのポジションにマウスのポジションを代入
            transform.position = Camera.main.ScreenToWorldPoint(_mousePos);
        }
    }
}
