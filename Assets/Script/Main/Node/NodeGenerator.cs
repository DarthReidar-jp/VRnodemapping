using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    //Nodeプレハブ関連宣言群（Node配列、選択用変数）
    public GameObject[] Nodes = new GameObject[3];
    public int nodeKind = 0;
	private Vector3 _nodePos;

    //マウス関連宣言群（マウス座標、ダブルクリック）
    private Vector3 _mousePos;
    private int _clickCount = 0;

    //Node複数選択用リスト

    public NodeSelect nodeSelect;
    public GameObject selectedNode;

    // Start is called before the first frame update
    void Start()
    {
       nodeSelect = gameObject.GetComponent<NodeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Nodeを複数選択できるようにする

            //ダブルクリックのカウントと0.3秒でダブルクリックチェック用関数を呼び出す
            _clickCount++;
            Invoke("DoubleClicks",0.3f);
        }
    }

    //ダブルクリック確認関数
    void DoubleClicks()
   {
        //ダブルタッチされているか
        if(_clickCount != 2) 
        { 
            _clickCount = 0; 
            return;
        }
        else
        { 
            _clickCount = 0; 
        }
        //Nodeの生成
        Generator();
   }

   //Nodeのインスタンス化関数
    void Generator ()
    {
        //マウスのポジションを代入
        _mousePos = Input.mousePosition;
		// Z軸を代入
		_mousePos.z = 5f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		_nodePos = Camera.main.ScreenToWorldPoint(_mousePos);
		// ワールド座標に変換されたマウス座標を代入
		Instantiate(Nodes[nodeKind],_nodePos,Quaternion.identity);
    }
}
