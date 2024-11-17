using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarryVault.Scripts
{
    // Game�V�[���ł�Scene�r���[�̂悤�ɃJ�����𑀍�ł���悤�ɂ���
    public class SceneLikeCamera : MonoBehaviour
    {
        [SerializeField] float _maxSpeed = 10.0f;
        [SerializeField] float _acceleration = 1.0f;
        [SerializeField] float _deceleration = 0.9f;
        [SerializeField] float _rotateSpeed = 5.0f;
        Vector3 _moveVelocity;

        // �J�����̃I�u�W�F�N�g
        Camera _camera;

        // Start is called before the first frame update
        void Start()
        {
            // �J�����̃I�u�W�F�N�g���擾
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
            // �}�E�X�̉E�N���b�N���łȂ���΂Ȃɂ����Ȃ�    
            if (!Input.GetMouseButton(1))
            {
                return;
            }

            Vector3 move_acc = Vector3.zero;

            // �J�����̈ړ�
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

            // ���x����
            if (_moveVelocity.magnitude > _maxSpeed)
            {
                _moveVelocity = _moveVelocity.normalized * _maxSpeed;
            }

            // �J�����̈ړ�
            _camera.transform.position += _moveVelocity;

            // ����
            _moveVelocity *= _deceleration;
        }

        void MouseMove()
        {
            // �}�E�X�̉E�N���b�N���łȂ���΂Ȃɂ����Ȃ�    
            if (!Input.GetMouseButton(1))
            {
                return;
            }

            // �}�E�X�̈ړ���
            float dx = Input.GetAxis("Mouse X") * _rotateSpeed;
            float dy = Input.GetAxis("Mouse Y") * _rotateSpeed;

            // �J�����̉�]
            _camera.transform.RotateAround(_camera.transform.position, Vector3.up, dx);
            _camera.transform.RotateAround(_camera.transform.position, _camera.transform.right, -dy);


        }
    }
}