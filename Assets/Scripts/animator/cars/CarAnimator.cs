using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CarAnimator : MonoBehaviour
    {
        private Animator _animator;
        private List<int> _path;
        private int[] _hashList;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _hashList = new int[8];

            _hashList[0] = Animator.StringToHash("goForward");
            _hashList[1] = Animator.StringToHash("goBack");
            _hashList[2] = Animator.StringToHash("goLeft");
            _hashList[3] = Animator.StringToHash("goRight");
            _hashList[4] = Animator.StringToHash("accelerateForward");
            _hashList[5] = Animator.StringToHash("accelerateBack");
            _hashList[6] = Animator.StringToHash("accelerateLeft");
            _hashList[7] = Animator.StringToHash("accelerateRight");

            // _path = CarPath.Get(gameObject);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _path = CarPath.Get(gameObject);
                StartCoroutine(_pathAnimator(0.2f));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _animator.SetTrigger(_hashList[1]);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _animator.SetTrigger(_hashList[2]);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _animator.SetTrigger(_hashList[3]);
            }
        }

        private IEnumerator _pathAnimator(float timer)
        {
            foreach (var anim in _path)
            {
                _animator.SetTrigger(_hashList[anim]);
                yield return new WaitForSeconds(timer);
            }
        }
    }
}
