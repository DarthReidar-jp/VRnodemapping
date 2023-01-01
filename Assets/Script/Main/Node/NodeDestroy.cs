using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroy : MonoBehaviour
{
    //セレクトスクリプトを格納する変数
    NodeSelect nodeSelect;
    // Start is called before the first frame update
    void Start()
    {
       //ノードセレクトスクリプトを取得
        nodeSelect = gameObject.GetComponent<NodeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
       //選択されたノードを削除する
        if (Input.GetMouseButtonDown(2))
        {
            nodeSelect.Select();
            Destroy(nodeSelect.selectNode);
        }
    }
}
