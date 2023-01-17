using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeShapeChange : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;

    NodeGenerator nodeGenerator;
    GameObject[] nodes;

    void Start()
    {
        nodeGenerator = gameObject.GetComponent<NodeGenerator>();
        nodes = nodeGenerator.Nodes;
    }

    // Update is called once per frame
    public void ShapeChange()
    {
        ChangeNodeInput();
        //DropdownのValueが0のとき（赤が選択されているとき）
        if(dropdown.value == 0)
        {
            ChangeNodeOutput();
        }
        //DropdownのValueが1のとき（青が選択されているとき）
        else if(dropdown.value == 1)
        {
            ChangeNodeOutput();
        }
        //DropdownのValueが2のとき（黄が選択されているとき）
        else if (dropdown.value == 2)
        {
           ChangeNodeOutput();
        }
        //DropdownのValueが3のとき（白が選択されているとき）
        else if (dropdown.value == 3)
        {
           
        }
        //DropdownのValueが4のとき（黒が選択されているとき）
        else if (dropdown.value == 4)
        {
        
        }
    }

    NodeUI nodeUI;
    GameObject originNode;
    //情報保持用
    Vector3 originNodePos;
    OverHeadMsgController originNodeText;
    string originText;

    void ChangeNodeInput()
    {
        //対象Nodeの選択
        nodeUI = gameObject.GetComponent<NodeUI>();
        originNode  = nodeUI.changeNode;

        //Node位置の保持
        originNodePos = nodeUI.changeNode.transform.position;

        //Node上文字の保持
        originNodeText  = nodeUI.changeNode.GetComponent<OverHeadMsgController>();
        originText = originNodeText.overHeadMsg.text;
    }

    public GameObject changedNode;
    OverHeadMsgController changedNodeText;
    void ChangeNodeOutput()
    {
        Destroy(originNode);
        changedNode = GameObject.Instantiate (nodes[dropdown.value],originNodePos,Quaternion.identity)as GameObject;
        changedNodeText = changedNode.GetComponent<OverHeadMsgController>();
        changedNodeText.overHeadMsg.text = originText;
    }
}
