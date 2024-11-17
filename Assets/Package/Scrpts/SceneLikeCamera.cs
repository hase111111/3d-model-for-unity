using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarryVault.Scripts
{
    // GameシーンでもSceneビューのようにカメラを操作できるようにする
    public class SceneLikeCamera : MonoBehaviour
    {
        [SerializeField] float _maxSpeed = 10.0f;
        [SerializeField] float _acceleration = 1.0f;
        [SerializeField] float _deceleration = 0.9f;
        [SerializeField] float _rotateSpeed = 5.0f;
        Vector3 _moveVelocity;

        // カメラのオブジェクト
        Camera _camera;

        // Start is called before the first frame update
        void Start()
        {
            // カメラのオブジェクトを取得
            _camera = FindObjectOfType<Camera>();

            if (_camera == null)
            {
                Debug.LogError("Camera not found");
            }
            else
            {
                Debug.Log("Camera found");
            }
        }

        // Update is called once per frame
        void Update()
        {
            KeyInput(_camera);
            MouseMove();
        }

        void KeyInput(Camera _camera)
        {
            // マウスの右クリック中でなければなにもしない    
            if (!Input.GetMouseButton(1))
            {
                return;
            }

            Vector3 move_acc = Vector3.zero;

            // カメラの移動
            if (Input.GetKey(KeyCode.W))
            {
                move_acc += _acceleration * Time.deltaTime * _camera.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move_acc -= _acceleration * Time.deltaTime * _camera.transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move_acc -= _acceleration * Time.deltaTime * _camera.transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                move_acc += _acceleration * Time.deltaTime * _camera.transform.right;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                move_acc -= _acceleration * Time.deltaTime * _camera.transform.up;
            }
            if (Input.GetKey(KeyCode.E))
            {
                move_acc += _acceleration * Time.deltaTime * _camera.transform.up;
            }

            _moveVelocity += move_acc;

            // 速度制限
            if (_moveVelocity.magnitude > _maxSpeed)
            {
                _moveVelocity = _moveVelocity.normalized * _maxSpeed;
            }

            // カメラの移動
            _camera.transform.position += _moveVelocity;

            // 減速
            _moveVelocity *= _deceleration;
        }

        void MouseMove()
        {
            // マウスの右クリック中でなければなにもしない    
            if (!Input.GetMouseButton(1))
            {
                return;
            }

            // マウスの移動量
            float dx = Input.GetAxis("Mouse X") * _rotateSpeed;
            float dy = Input.GetAxis("Mouse Y") * _rotateSpeed;

            // カメラの回転
            _camera.transform.RotateAround(_camera.transform.position, Vector3.up, dx);
            _camera.transform.RotateAround(_camera.transform.position, _camera.transform.right, -dy);


        }
    }
}