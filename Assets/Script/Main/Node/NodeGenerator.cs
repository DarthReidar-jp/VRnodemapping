using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    //Nodeプレハブの配列
    public GameObject[] Nodes = new GameObject[3];
    //Nodeプレハブ選択用変数
    public int nodeKind = 0;
    //現在のマウス座標
    private Vector3 _mousePos;
    // Nodeの座標
	private Vector3 _nodePos;
    //ダブルクリックの確認
    private int _touchCount = 0;

    NodeSelect nodeSelect;

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

            //ダブルクリックのカウント
            _touchCount++;
            //0.3秒でダブルクリックチェック用関数を呼び出す
            Invoke("DoubleClicks",0.3f);
        }
    }

    //ダブルクリック確認関数
      void DoubleClicks()
   {
       //ダブルタッチされているか
       if(_touchCount != 2) { 
        _touchCount = 0; 
        return;
        }else{ 
        _touchCount = 0; }
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
