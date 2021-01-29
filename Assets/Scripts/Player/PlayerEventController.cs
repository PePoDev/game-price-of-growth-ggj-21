using System;
using Dialog;
using Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerEventController : MonoBehaviour
    {
        public DialogController dialogController;
        public Transform dialogPosition;

        private DialogBox _dialogBox;
        private Collider2D _triggerObject;
        
        private void Start()
        {
            _dialogBox = dialogController.CreateDialogBox("", dialogPosition, 0f);
        }

        private void Update()
        {
            if (!Input.GetButtonDown(Statics.INPUT_ACTION)) return;
            
            _triggerObject.GetComponent<IEvent>().Trigger();
            Lebug.Log("Last Event Name", _triggerObject.GetComponent<IEvent>().GetEventName(), "Event");
            Lebug.Log("Last Event Time", Time.time, "Event");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Statics.TAG_TRIGGER)) return;

            var eventActionName = other.GetComponent<IEvent>().GetActionName();
            _dialogBox.SetDialogBox(eventActionName, dialogPosition, 0f);
            _dialogBox.Show();

            _triggerObject = other;
            Lebug.Log("Last Action Name", eventActionName, "Event");
            Lebug.Log("Last Action Time", Time.time, "Event");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag(Statics.TAG_TRIGGER)) return;

            _dialogBox.Hide(true);
            _triggerObject = null;
        }
    }
}