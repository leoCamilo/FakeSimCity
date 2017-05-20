using System.Collections;
using UnityEngine;

namespace Cariacity.game
{
    public enum CarAnimationDirection { Forward, Right, Left, Return }

    public class CarAnimator : MonoBehaviour
    {
        private const float carAnimationDuration = 0.5f;
        private Animator _animator;
        private int[] _hashList;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _hashList = new int[4];

            _hashList[0] = Animator.StringToHash("go_forward");
            _hashList[1] = Animator.StringToHash("turn_right");
            _hashList[2] = Animator.StringToHash("turn_left");
            _hashList[3] = Animator.StringToHash("return");

            StartCoroutine(_pathAnimator(carAnimationDuration));
        }

        private IEnumerator _pathAnimator(float timer)
        {
            while (true)
            {
                yield return new WaitForSeconds(timer);
                _animator.SetTrigger(_hashList[(int)CarPath.Get(gameObject)]);
            }
        }
    }
}