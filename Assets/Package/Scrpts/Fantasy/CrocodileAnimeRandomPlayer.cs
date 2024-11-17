using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarryVault.Scripts.Fantasy
{
    public class CrocodileAnimeRandomPlayer : MonoBehaviour
    {
        float _timer = 0.0f;
        readonly float _interval = 2.0f;

        Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _interval)
            {
                _timer = 0.0f;
                _animator.SetBool("isWalking", Random.Range(0, 2) == 0);
            }
        }
    }
}
