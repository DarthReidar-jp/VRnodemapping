using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBranch : MonoBehaviour
{
    public GameObject branch;
    GameObject _selectNode;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            //マウスがノード上にいるか確認
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit = new RaycastHit();
            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider.gameObject.CompareTag("Node"))
                {
                    _selectNode = _hit.collider.gameObject;
                    Invoke("_addLineObject",0.3f);
                }
            }
        }   
    }

    private void _addLineObject()
    {
        GameObject childObject = Instantiate(branch) as GameObject;
        childObject.transform.parent = _selectNode.transform;
    }
}



