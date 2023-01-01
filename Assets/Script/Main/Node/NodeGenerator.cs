using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    //Nodeプレハブの配列
    public GameObject[] Nodes = new GameObject[3];
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
            nodeSelect.Select();
            _touchCount++;
            Invoke("DoubleClicks",0.3f);
        }
    }

    void Generator ()
    {
        _mousePos = Input.mousePosition;
		// Z軸を代入
		_mousePos.z = 5f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		_nodePos = Camera.main.ScreenToWorldPoint(_mousePos);
		// ワールド座標に変換されたマウス座標を代入
		Instantiate(Nodes[0],_nodePos,Quaternion.identity);
    }

      void DoubleClicks()
   {
       //ダブルタッチされているか
       if(_touchCount != 2) { _touchCount = 0; return; }     
       else{ _touchCount = 0; }
       
       //Nodeの生成
       Generator();
   }
}
