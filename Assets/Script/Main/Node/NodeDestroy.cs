using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDestroy : MonoBehaviour
{
    //セレクトスクリプトを格納する変数
    NodeSelect nodesSelect;
    // Start is called before the first frame update
    void Start()
    {
        nodesSelect = gameObject.GetComponent<NodeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            nodesSelect.Select();
            Destroy(nodesSelect.selectNode);
        }
    }
}
