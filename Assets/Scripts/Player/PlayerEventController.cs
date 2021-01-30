using System;
using Dialog;
using Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerEventController : MonoBehaviour
    {
        public Transform dialogPosition;
        public DialogBox dialogBox;

        private Collider2D _triggerObject;

        private void Update()
        {
	        if (!Input.GetButtonDown(Statics.INPUT_SUBMIT) || _triggerObject == null) return;

            Lebug.Log("Last Event Name", _triggerObject.GetComponent<IEvent>().GetEventName(), "Event");
            Lebug.Log("Last Event Time", Time.time, "Event");
            _triggerObject.GetComponent<IEvent>().Trigger();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag(Statics.TAG_TRIGGER)) return;

            var eventActionName = other.collider.GetComponent<IEvent>().GetActionName();
            dialogBox.SetDialogBox($"<wiggle>{eventActionName}</wiggle>", dialogPosition, 0f);
            dialogBox.enabled = true;
            dialogBox.Show();

            _triggerObject = other.collider;
            Lebug.Log("Last Action Name", eventActionName, "Event");
            Lebug.Log("Last Action Time", Time.time, "Event");
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.collider.CompareTag(Statics.TAG_TRIGGER)) return;

            dialogBox.Hide(true);
            _triggerObject = null;
        }
    }
}