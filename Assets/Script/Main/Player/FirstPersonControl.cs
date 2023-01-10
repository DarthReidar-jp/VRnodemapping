using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControl : MonoBehaviour
{
    //_付きの変数はプライベート、無しの変数はパブリック
    
    //プレイヤー関連変数宣言群（移動量、速度、角度）
    float _xAmount, _zAmount;
    float _speed = 0.1f;
    Quaternion _playerRot;

    //カメラ関連変数宣言群（ゲームオブジェクト、角度、感度）
    public GameObject cam;
    Quaternion _cameraRot;
    float _minX = -90f, _maxX = 90f;
    float _Xsensityvity = 3f, _Ysensityvity = 3f;
    
    //マウス関連変数宣言群（マウス入力を角度にしたもの,カーソルロック）
    float _xInputRot , _yInputRot;
    bool _isCursorLock = true;
    //NodeUIスクリプト格納用
    NodeUI _nodeUI;

    void Start()
    {
        //カメラ角度、プレイヤー角度、NodeUIの取得
        _cameraRot = cam.transform.localRotation;
        _playerRot = transform.localRotation;
        _nodeUI = GameObject.Find("NodeManager").GetComponent<NodeUI>();
    }

    void Update()
    {
        //もしUIが非表示ならば、カメラの移動を許可する
        if (_nodeUI.isUIenable == false)
        {
            //マウスの動きからxとyの角度を代入
            _xInputRot = Input.GetAxis("Mouse X") * _Ysensityvity;
            _yInputRot = Input.GetAxis("Mouse Y") * _Xsensityvity;
            //インプット角度をオイラー角度にしてカメラとプレイヤーの角度に代入
            _cameraRot *= Quaternion.Euler(-_yInputRot, 0, 0);
            _playerRot *= Quaternion.Euler(0, _xInputRot, 0);
            //カメラ角度は制限を加える
            _cameraRot = ClampRotation(_cameraRot);
            //カメラとプレイヤーの角度を実体に代入
            cam.transform.localRotation = _cameraRot;
            transform.localRotation = _playerRot;
            //カーソルロック関数を呼び出す
            UpdateCursorLock();
        }
        
    }
    
    void FixedUpdate()
    {
        //もしUIが非表示ならば、移動を許可する
        if (_nodeUI.isUIenable ==false)
        {
            //x軸とz軸の移動量の初期化
            _xAmount = 0;
            _zAmount = 0;
            //左右前後の移動の入力
            _xAmount = Input.GetAxisRaw("Horizontal") * _speed;
            _zAmount = Input.GetAxisRaw("Vertical") * _speed;
            //左右前後移動の実施
            transform.position += cam.transform.forward * _zAmount + cam.transform.right * _xAmount;
        }   
    }

    //カーソルロック関数
    public void UpdateCursorLock()
    {
        //もしescapeが押されたらカーソルロックを偽にする
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _isCursorLock = false;
        }
        //もしPが押されたらカーソルロックを真にする。
        else if(Input.GetKeyDown(KeyCode.P))
        {
            _isCursorLock = true;
        }

        //真だったら、カーソルロックする
        if (_isCursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        //偽だったら、カーソルロックを解除する
        else if(!_isCursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    //角度制限関数（2023年1月時点はよくわかっていない。）
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