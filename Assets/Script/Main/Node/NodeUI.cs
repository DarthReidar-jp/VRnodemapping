using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    //_付きの変数はプライベート、無しの変数はパブリック

    //UI関連変数宣言群（変更Node,UI表示中）
    public GameObject changeNode;
    public bool isUIenable = false;

    //セレクトスクリプトを格納する変数
    NodeSelect _nodeSelect;

    //パネルを格納する変数
    [SerializeField] GameObject _panel;

    void Start()
    {
        //ノードセレクトのスクリプトを取得
        _nodeSelect = gameObject.GetComponent<NodeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        //もし、右クリックかつ選ばれたノードがあれば
        if (Input.GetMouseButtonDown(1))
        {
            //セレクトノードをチェンジノードに格納する
            changeNode = _nodeSelect.SelectNode();
            if (changeNode != null)
            {
                //UIパネルを表示する
                _panel.SetActive(true);
                //UIフラグを正にする
                isUIenable = true;
            }
        }
        //もしTabが押されたら
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //パネルを非表示にして、 UIフラグを負にする
            _panel.SetActive(false);
            changeNode = null;
            isUIenable = false;
        }
    }
}
