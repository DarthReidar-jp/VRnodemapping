using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroy : MonoBehaviour
{
    //セレクトスクリプトを格納する変数
    NodeSelect _nodeSelect;

    void Start()
    {
       //ノードセレクトスクリプトを取得
        _nodeSelect = gameObject.GetComponent<NodeSelect>();
    }

    void Update()
    {
       //選択されたノードを削除する
        if (Input.GetMouseButtonDown(2))
        {
            Destroy(_nodeSelect.SelectNode());
        }
    }
}
