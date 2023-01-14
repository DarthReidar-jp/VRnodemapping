using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBranch : MonoBehaviour
{
    LineRenderer lineRenderer;
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

    //ブランチがノードと繋がっているかのフラグ
    bool isBranchCorect = false;
    RaycastHit hitNode;
    GameObject _purposeNode;
    // Update is called once per frame
    void Update()
    {
        Vector3 parentNode = transform.parent.position;
        if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && isBranchCorect==false)
        {
		    Vector3 position = Input.mousePosition;
		    position.z = 10f;
		    var screenToWorldPoint = Camera.main.ScreenToWorldPoint(position);

            //親ノードとマウスポインタの線を描画
            lineRenderer.SetPosition(0, parentNode);
            lineRenderer.SetPosition(1, screenToWorldPoint);

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(rayOrigin, out hitNode))
            {
                if (hitNode.collider.CompareTag("Node"))
                {
                    _purposeNode = hitNode.collider.gameObject;
                    lineRenderer.SetPosition(0, parentNode);
                    lineRenderer.SetPosition(1, _purposeNode.transform.position);
                    isBranchCorect = true;
                }
            }
        }

        if (isBranchCorect)
        {
            lineRenderer.SetPosition(0, parentNode);
            lineRenderer.SetPosition(1, _purposeNode.transform.position);
        }

        if (Input.GetMouseButtonUp(0)&& isBranchCorect ==false)
        {
            Destroy(this.gameObject);
        }

    }
}

