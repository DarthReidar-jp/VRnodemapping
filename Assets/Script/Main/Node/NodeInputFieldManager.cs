using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInputFieldManager : MonoBehaviour
{   
    //InputFieldを格納するための変数
    InputField _inputField;
    //NodeUIスクリプトを入れる変数
    NodeUI nodeUI;
    //テキストを変更するNodeのテキストを入れる変数
    OverHeadMsgController textchangeNode;

    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputText()
    {
        //InputFieldコンポーネントを取得
        _inputField = GameObject.Find("InputField").GetComponent<InputField>();
        //NodoUIスクリプトを取得
        nodeUI = gameObject.GetComponent<NodeUI>();
        //NodeUIで選択されたNodeのテキストスクリプトを取得する
        textchangeNode  = nodeUI.changeNode.GetComponent<OverHeadMsgController>();
        //InputFieldからテキスト情報を取得する
        textchangeNode.overHeadMsg.text = _inputField.text;
        //入力フォームのテキストを空にする
        _inputField.text = "";
    }
}
