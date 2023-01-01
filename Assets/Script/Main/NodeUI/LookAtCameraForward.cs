using UnityEngine;

public class LookAtCameraForward : MonoBehaviour
{
    void Update()
    {
        //カメラの方向を見続けるテキスト
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}