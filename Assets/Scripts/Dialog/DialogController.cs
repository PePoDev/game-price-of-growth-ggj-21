using UnityEngine;
using UnityEngine.Serialization;
using Debug = System.Diagnostics.Debug;

namespace Dialog
{
    public class DialogController : MonoBehaviour
    {
        public DialogBox dialogBoxPrefab;

        public DialogBox CreateDialogBox(string msg, Transform target, float timeout = Statics.DEFAULT_DIALOG_TIMEOUT)
        {
            var dialogBox = Instantiate(dialogBoxPrefab, dialogBoxPrefab.transform.position, dialogBoxPrefab.transform.rotation);
            dialogBox.transform.SetParent(transform, false);
            dialogBox.SetDialogBox(msg, target, timeout);

            return dialogBox;
        }
    }
}
