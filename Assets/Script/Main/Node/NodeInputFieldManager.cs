using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//今のところ全然わかりません＞＜

public class NodeInputFieldManager : MonoBehaviour
{   
    //InputFieldを格納するための変数
    InputField inputField;

    NodeUI nodeUI;

    OverHeadMsgController textchangeNode;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        //NodoUIスクリプトを取得
        nodeUI = gameObject.GetComponent<NodeUI>();
        textchangeNode  = nodeUI.changeNode.GetComponent<OverHeadMsgController>();

    }

    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        textchangeNode.overHeadMsg.text = inputField.text;

        //入力フォームのテキストを空にする
        inputField.text = "";
    }
}
