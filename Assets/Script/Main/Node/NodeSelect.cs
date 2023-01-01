using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelect : MonoBehaviour
{   
    //クリックしたNodeを格納する変数（配列になる）
    GameObject _clickedObject;
    //選択したNodeを格納
    public GameObject selectNode;
    //rayを格納する変数
    private Ray _ray;
    //RaycastのHitを格納する変数
    private RaycastHit _hit;

    //Nodeを選択する関数
    public void Select()
     {
        //もしクリックしたオブジェクトが空なら
        if (_clickedObject == null)
        {
            //マウスのレイを取得
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //raycasthitを取得
            _hit = new RaycastHit();
            //もしレイキャストで帰ってくるものがあれば
            if (Physics.Raycast(_ray, out _hit)) {
                //クリックオブジェクトに当たったものを格納
                _clickedObject = _hit.collider.gameObject;
            //もしクリックオブジェクトがNodeなら
             if (_clickedObject.CompareTag("Node"))
                 {
                    //パブリックな変数に格納
                    selectNode = _clickedObject;
                    Debug.Log(selectNode);   
                }
            }
        }
        //空じゃなかったら
        else if (_clickedObject!= null)
        {
            //クリックしたオブジェクトを空にする
            _clickedObject = null;
        }
        
    }
}
