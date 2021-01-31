using System.Collections;
using System.Collections.Generic;
using Dialog;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Objective
{
    public class O_1_2 : MonoBehaviour, IObjective
    {
        public TextMeshProUGUI textObjective;
        public DialogController dialogController;
        public Transform momDialogPosition;
        private GameObject _playerObject;

        private void Start()
        {
            _playerObject = GameObject.FindGameObjectWithTag(Statics.TAG_PLAYER);
        }

        public void ShowMomMessage()
        {
            var d = dialogController.CreateDialogBox("Help Me, I Will Cook", momDialogPosition, 5f);
            d.Show();
            textObjective.text = "1. Fill water in bottle\n2. Put bottle to Refrigerator\n3. Waiting on sofa";
        }

        public void HideHiddenMessage(GameObject target)
        {
            StartCoroutine(hide());
            IEnumerator hide()
            {
                yield return new WaitForSeconds(3f);
                target.SetActive(false);
            }
        }
        
        public void ShowPlayer(Animator animator)
        {
            StartCoroutine(Show());
            IEnumerator Show()
            {
                yield return new WaitForSeconds(0.5f);
                while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    yield return null;
                _playerObject.SetActive(true);
                _playerObject.GetComponent<PlayerMovementController>().enabled = true;
            }
        }

        public void LoadNextScene()
        {
            StartCoroutine(Task());
            IEnumerator Task()
            {
                yield return new WaitForSeconds(3f);
                Initiate.Fade("Chapter 1-3", Color.black, 1f);
            }
        }

        public void IncrementTask()
        {
        }

        public bool IsSolved() => false;
    }
}