using System;
using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class StartStory : MonoBehaviour
{

    public TextMeshProUGUI textDialog;

    private TextAnimator _textAnimator;

    private void Start()
    {
        _textAnimator = textDialog.GetComponent<TextAnimator>();
    }

    public void LoadNextScene()
    {
        Initiate.Fade("Chapter 1", Color.black, 1f);
    }

    public void ChangeText(string text)
    {
        _textAnimator.SyncText(text, false);
    }
}
