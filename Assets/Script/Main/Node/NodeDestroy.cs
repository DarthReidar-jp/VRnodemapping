using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroy : MonoBehaviour
{
    //セレクトスクリプトを格納する変数
    NodeSelect _nodeSelect;
    //破壊するNodeを格納する変数
    GameObject destroyNode;
    // Start is called before the first frame update
    void Start()
    {
       //ノードセレクトスクリプトを取得
        _nodeSelect = gameObject.GetComponent<NodeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
       //選択されたノードを削除する
        if (Input.GetMouseButtonDown(2))
        {
            destroyNode = _nodeSelect.SelectReturn();
            Debug.Log(destroyNode + "を削除しました");
            Destroy(destroyNode);
        }
    }
}
