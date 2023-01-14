using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBranch : MonoBehaviour
{
    public GameObject branch;

    public GameObject selectNode;


    void start()
    {
        
    }

    void Update()
    {
        //やりたいことは、
        //選択されているノードのみから線を引きたい。
        //現状は出ているすべてのノードから線が引かれてしまう。
        //その原因はすべてのノードのこのスクリプトが動いてしまうから。
        //対策として、現在マウスが上に乗っているノードのみから線を引くという条件を足したい。
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            //マウスの位置を取得、新しいレイを作成してそれをhitに入れる
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit = new RaycastHit();
            //もしマウスから飛んだレイに衝突したものがあれば当たったものを取得する
            if (Physics.Raycast(_ray, out _hit))
            {
                GameObject _clickedObject = _hit.collider.gameObject;
                //当たった対象がNodeなら、選択Nodeとして格納
                if (_clickedObject.CompareTag("Node"))
                {
                    selectNode = _clickedObject;
                    Invoke("_addLineObject",0.5f);
                }
            }
        }   
        
    }

    private void _addLineObject()
    {
        
        GameObject childObject = Instantiate(branch) as GameObject;
        childObject.transform.parent = selectNode.transform;
        //Debug.Log("ブランチ作れたよ");
    }
    }



