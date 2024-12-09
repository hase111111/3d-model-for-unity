
#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarryVault.Scripts
{
    // Allow the camera to be controlled in Game scenes as in Scene views.
    public class SceneLikeCamera : MonoBehaviour
    {
        [SerializeField] float _maxSpeed = 10.0f;
        [SerializeField] float _acceleration = 1.0f;
        [SerializeField] float _deceleration = 0.9f;
        [SerializeField] float _rotateSpeed = 5.0f;
        Vector3 _moveVelocity;
        Camera? _camera;

        void Start()
        {
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

        void Update()
        {
            KeyInput(_camera);
            MouseMove();
        }

        void KeyInput(Camera? _camera)
        {
            if (_camera == null) return;

            // Do nothing unless you are in the middle of a right mouse click. 
            if (!Input.GetMouseButton(1))
            {
                return;
            }

            Vector3 move_acc = Vector3.zero;

            // Move the camera.
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

            // Limit the speed.
            if (_moveVelocity.magnitude > _maxSpeed)
            {
                _moveVelocity = _moveVelocity.normalized * _maxSpeed;
            }

            _camera.transform.position += _moveVelocity;

            // Deceleration.
            _moveVelocity *= _deceleration;
        }

        void MouseMove()
        {
            if (_camera == null) return;

            // Do nothing unless you are in the middle of a right mouse click.
            if (!Input.GetMouseButton(1))
            {
                return;
            }

            float dx = Input.GetAxis("Mouse X") * _rotateSpeed;
            float dy = Input.GetAxis("Mouse Y") * _rotateSpeed;

            _camera.transform.RotateAround(_camera.transform.position, Vector3.up, dx);
            _camera.transform.RotateAround(_camera.transform.position, _camera.transform.right, -dy);
        }
    }
}