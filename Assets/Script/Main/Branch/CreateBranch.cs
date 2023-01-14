using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBranch : MonoBehaviour
{
    public GameObject branch;
    NodeGenerator nodeGenerator;
    NodeSelect nodeSelect;

    void start()
    {
        nodeGenerator = GameObject.Find("NodeManager").GetComponent<NodeGenerator>();
        nodeSelect= GameObject.Find("NodeManager").GetComponent<NodeSelect>();
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
            _addLineObject();
        }   
        
    }

    private void _addLineObject()
    {
        GameObject childObject = Instantiate(branch) as GameObject;
        childObject.transform.parent = this.transform;
    }
    }



