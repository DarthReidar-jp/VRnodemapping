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

    void Update(){
        //もしスペースが押されたらセレクトを解除する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Deselect();
        }
    }

    //Nodeを選択する関数
    public void Select()
     {
            _clickedObject = null;
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
        
    public void Deselect(){
        selectNode = null;
    }
}
