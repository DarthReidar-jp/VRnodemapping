using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeColorChange : MonoBehaviour
{
    //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown;

    // Update is called once per frame
    public void ColorChange()
    {
        NodeUI nodeUI = gameObject.GetComponent<NodeUI>();
        GameObject colorchangeNode  = nodeUI.changeNode;

        //DropdownのValueが0のとき（赤が選択されているとき）
        if(dropdown.value == 0)
        {
            colorchangeNode.GetComponent<Renderer>().material.color = Color.red;
        }
        //DropdownのValueが1のとき（青が選択されているとき）
        else if(dropdown.value == 1)
        {
            colorchangeNode.GetComponent<Renderer>().material.color = Color.blue;
        }
        //DropdownのValueが2のとき（黄が選択されているとき）
        else if (dropdown.value == 2)
        {
            colorchangeNode.GetComponent<Renderer>().material.color = Color.yellow;
        }
        //DropdownのValueが3のとき（白が選択されているとき）
        else if (dropdown.value == 3)
        {
            colorchangeNode.GetComponent<Renderer>().material.color = Color.white;
        }
        //DropdownのValueが4のとき（黒が選択されているとき）
        else if (dropdown.value == 4)
        {
            colorchangeNode.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
