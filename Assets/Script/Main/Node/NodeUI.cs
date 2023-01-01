using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
     //セレクトスクリプトを格納する変数
    public NodeSelect nodeSelect;
    // UIを変更するNodeを格納する変数
    public GameObject changeNode;
        //UI表示中のフラグ
    public bool UIenable = false;
    //パネルを格納する変数
    [SerializeField] GameObject _panel;

    // Start is called before the first frame update
    void Start()
    {
        //ノードセレクトのスクリプトを取得
        nodeSelect = gameObject.GetComponent<NodeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        //もし、右クリックかつ選ばれたノードがあれば
        if (Input.GetMouseButtonDown(1) && nodeSelect.selectNode != null)
        {
            //テスト用
            Debug.Log("選択できたよ");
            // UIパネルを表示する
            _panel.SetActive(true);
            // UIフラグを正にする
            UIenable = true;
            //セレクトノードをチェンジノードに格納する
            changeNode = nodeSelect.selectNode;
        }
        //もし左シフトが押されたら
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //パネルを非表示にして、 UIフラグを負にする
            _panel.SetActive(false);
            UIenable = false;
        }

    }
}