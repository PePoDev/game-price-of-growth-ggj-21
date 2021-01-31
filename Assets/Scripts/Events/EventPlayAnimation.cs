using System;
using System.Collections;
using Objective;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Events
{
    public class EventPlayAnimation : MonoBehaviour, IEvent
    {
        public string actionName;
        public string eventName;
        public bool disableOnCompleted = false;

        private Animator _targetAnimator;
        private GameObject _player;
        private IObjective _objective;
        private static readonly int AnimatorTriggerName = Animator.StringToHash("Trigger");
        private bool _alreadyIncrement = false;

        private void Start()
        {
            _targetAnimator = GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag(Statics.TAG_PLAYER);
            _objective = GameObject.FindGameObjectWithTag(Statics.TAG_OBJECTIVE).GetComponent<IObjective>();
        }

        public void Trigger()
        {
            _targetAnimator.SetTrigger(AnimatorTriggerName);
            _player.SetActive(false);

            if (disableOnCompleted)
            {
                gameObject.tag = "Untagged";
            }

            if (_alreadyIncrement == false)
            {
                _alreadyIncrement = true;
                _objective.IncrementTask();
            }

            StartCoroutine(OnCompleteAnimation());
        }

        private IEnumerator OnCompleteAnimation()
        {
            yield return new WaitForSeconds(0.5f);

            while (!_targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                yield return null;

            _player.SetActive(true);
        }

        public string GetActionName() => actionName;
        public string GetEventName() => eventName;
    }
}