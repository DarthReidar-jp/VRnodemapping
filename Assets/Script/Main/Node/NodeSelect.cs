using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelect : MonoBehaviour
{   
    //クリックしたオブジェクトを格納する変数
    GameObject _clickedObject;
    //選択したNodeを格納
    public GameObject selectNode;
    //rayを格納する変数
    private Ray _ray;
    //RaycastのHitを格納する変数
    private RaycastHit _hit;

    //Nodeを選択する関数（選択したゲームオブジェクトを返す）
    public GameObject Select()
    {
        //クリックオブジェクトを空にする
        _clickedObject = null;
        //マウスの位置を取得、新しいレイを作成してそれをhitに入れる
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _hit = new RaycastHit();
        //もしマウスから飛んだレイに衝突したものがあれば当たったものを取得する
        if (Physics.Raycast(_ray, out _hit))
        {
            _clickedObject = _hit.collider.gameObject;
            //当たった対象がNodeなら、選択Nodeとして格納
            if (_clickedObject.CompareTag("Node"))
            {
                selectNode = _clickedObject;
            }
        }
        //選択したNodeを返す
        return selectNode;
    }
    
}
