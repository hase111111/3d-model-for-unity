
#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarryVault.Scripts.Fantasy
{
    public class CrocodileAnimeRandomPlayer : MonoBehaviour
    {
        [SerializeField] float interval = 2.0f;
        float _timer = 0.0f;

        Animator? _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (_animator == null) return;

            _timer += Time.deltaTime;

            if (_timer > interval)
            {
                bool is_walking = Random.Range(0, 2) == 0;
                _timer = 0.0f;
                _animator.SetBool("isWalking", is_walking);
            }
        }
    }
}
