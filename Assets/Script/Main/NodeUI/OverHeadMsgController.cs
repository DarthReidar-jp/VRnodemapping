using UnityEngine;
using UnityEngine.UI;

public class OverHeadMsgController : MonoBehaviour
{
    //テキスト型の変数を宣言
    [SerializeField] Text overHeadMsg;

    void Update()
    {
        //テスト用、スペースキーが押されたらテキストを変える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            overHeadMsg.text = "Hello";
        }
    }
}
