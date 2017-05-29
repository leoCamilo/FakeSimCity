using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public enum CarAnimationDirection { Forward, Right, Left, Return }

    public class CarAnimator : MonoBehaviour
    {
        private const float carAnimationDuration = 0.75f;
        private KeyValuePair<float, int>[] _animationList;
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _animationList = new KeyValuePair<float, int>[4];

            _animationList[0] = new KeyValuePair<float, int>(0.75f, Animator.StringToHash("go_forward"));
            _animationList[1] = new KeyValuePair<float, int>(1.5f, Animator.StringToHash("turn_right"));
            _animationList[2] = new KeyValuePair<float, int>(1.5f, Animator.StringToHash("turn_left"));
            _animationList[3] = new KeyValuePair<float, int>(0.75f, Animator.StringToHash("return"));

            StartCoroutine(_pathAnimator(carAnimationDuration));
        }

        private IEnumerator _pathAnimator(float timer)
        {
            while (true)
            {
                var animationItem = _animationList[(int)CarPath.Get(gameObject)];
                _animator.SetTrigger(animationItem.Value);
                yield return new WaitForSeconds(animationItem.Key);
            }
        }
    }
}