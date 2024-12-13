
#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarryVault.Scripts.Fantasy
{
    public class ScorpionAnimeRandomPlayer : MonoBehaviour
    {
        [SerializeField] float interval = 2.0f;
        float _timer = 0.0f;

        Animator? _animator;

        void Start()
        {
            if (!TryGetComponent<Animator>(out _animator))
            {
                Debug.LogError("Animator is not found.");
            }
        }

        void Update()
        {
            if (_animator == null) return;

            _timer += Time.deltaTime;

            if (_timer > interval)
            {
                int anime_index = Random.Range(0, 4);
                _timer = 0.0f;
                _animator.SetInteger("AnimeIndex", anime_index);
            }
        }
    }
}
