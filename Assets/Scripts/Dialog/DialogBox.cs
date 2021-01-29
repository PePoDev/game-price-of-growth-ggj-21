using System;
using System.Collections;
using Febucci.UI;
using TMPro;
using UnityEngine;

namespace Dialog
{
    public class DialogBox : MonoBehaviour
    {
        public TextMeshProUGUI textMessage;

        private Transform _targetPosition;
        private float _timeout;
        private RectTransform _rectTransform;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _rectTransform = GetComponent<RectTransform>();
        }

        private void LateUpdate()
        {
            var dialogPosition = _camera.WorldToScreenPoint(_targetPosition.position);
            transform.position = dialogPosition;
            
            Lebug.Log("playerTargetDialogBoxPosition", _targetPosition.position, "DialogBox");
            Lebug.Log("dialogBoxPosition", dialogPosition, "DialogBox");
        }

        public void SetDialogBox(string msg, Transform targetPosition, float timeout = Statics.DEFAULT_DIALOG_TIMEOUT)
        {
            textMessage.text = msg;
            _timeout = timeout;
            _targetPosition = targetPosition;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            if (_timeout > 0) StartCoroutine(DelayDestroyDialogBox(_timeout));
        }

        public void Hide(bool soft = false)
        {
            if (soft)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator DelayDestroyDialogBox(float timeout)
        {
            yield return new WaitForSeconds(timeout);
            Destroy(gameObject);
        }
    }
}