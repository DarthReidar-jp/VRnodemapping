using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBranch : MonoBehaviour
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    bool isBranchCorect = false;
    RaycastHit hitNode;
    public bool isBranchDrawing;
    // Update is called once per frame
    void Update()
    {
        //このオブジェクトの位置を格納
        Vector3 thisNode = transform.parent.position;
        //もし左ホールドとシフトが押されたら
        if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && isBranchCorect==false)
        {
            // Vector3でマウス位置座標を取得する
		    Vector3 position = Input.mousePosition;
		    // Z軸にこのNodeのZ位置を入れる
		    position.z = 10f;
		    // マウス位置座標をスクリーン座標からワールド座標に変換する
		    var screenToWorldPoint = Camera.main.ScreenToWorldPoint(position);

            //このノードとマウスポインタの線を描画
            lineRenderer.SetPosition(0, thisNode);
            lineRenderer.SetPosition(1, screenToWorldPoint);

            //マウスからのレイを格納
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            //もしレイが何かオブジェクトにヒットしたら以下の処理を行う
            if(Physics.Raycast(rayOrigin, out hitNode))
             {
                //もしヒットしたオブジェクトがPlayerなら
                if (hitNode.collider.CompareTag("Node"))
                {
                    //このノードと目的ノードのブランチを描画
                    lineRenderer.SetPosition(0, thisNode);
                    lineRenderer.SetPosition(1, hitNode.transform.position);
                    //ブランチが決定
                    isBranchCorect = true;
                }
             }
        }
        if (isBranchCorect)
        {
            lineRenderer.SetPosition(0, thisNode);
            lineRenderer.SetPosition(1, hitNode.transform.position);
        }     
        if (Input.GetMouseButtonUp(0)&& isBranchCorect ==false)
        {
            Destroy(this.gameObject);
        }

        isBranchDrawing = false;
    }
}

