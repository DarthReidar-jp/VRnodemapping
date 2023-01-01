using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControl : MonoBehaviour
{
    //
    float _xPos, _zPos;
    //プレイヤーの速度変数
    [SerializeField] float _speed = 0.1f;
    //カメラオブジェクトの取得
    public GameObject cam;
    //カメラの角度と、プレイヤの角度変数
    Quaternion _cameraRot, _playerRot;
    //x感度とy感度変数
    float _Xsensityvity = 3f, _Ysensityvity = 3f;
    //カーソルロックの確認変数
    bool _cursorLock = true;
    //角度の制限用
    float _minX = -90f, _maxX = 90f;
    //UI表示中か確認
    NodeUI nodeUI;

    // Start is called before the first frame update
    void Start()
    {
        //カメラのローカル角度の取得
        _cameraRot = cam.transform.localRotation;
        //プレイヤーのローカル角度の取得
        _playerRot = transform.localRotation;
        //nodeUIの取得
        nodeUI = GameObject.Find("NodeManager").GetComponent<NodeUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nodeUI.UIenable == false)
        {
            //マウスの動きからxとyの角度を代入
        float xRot = Input.GetAxis("Mouse X") * _Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * _Xsensityvity;
        //その角度をオイラー角度にしてそれぞれの角度に代入
        _cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        _playerRot *= Quaternion.Euler(0, xRot, 0);

        //角度制限を加えて再代入
        _cameraRot = ClampRotation(_cameraRot);
        //変数を実際のコンポーネントに代入
        cam.transform.localRotation = _cameraRot;
        transform.localRotation = _playerRot;
        //カーソルロック関数
        UpdateCursorLock();

        }
        
    }
    
    //移動用fixrdUpdate
    private void FixedUpdate()
    {
        if (nodeUI.UIenable ==false)
        {
            //xposとzposに０を代入
        _xPos = 0;
        _zPos = 0;
        //水平と垂直入力にスピードをかけてそれぞれのポジションに代入
        _xPos = Input.GetAxisRaw("Horizontal") * _speed;
        _zPos = Input.GetAxisRaw("Vertical") * _speed;

        //transform.position += new Vector3(x,0,z);
        transform.position += cam.transform.forward * _zPos + cam.transform.right * _xPos;
        }
        
    }

    ///カーソルロックの関数
    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _cursorLock = false;
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            _cursorLock = true;
        }


        if (_cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!_cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,_minX,_maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
}