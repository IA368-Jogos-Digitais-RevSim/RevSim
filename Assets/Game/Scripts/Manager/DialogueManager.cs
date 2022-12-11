using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private GameObject _nextComponent;

    [Header("Settings")]
    [Range(1.0f, 100.0f)] [SerializeField] private float _speakingTime;
    [SerializeField] private string _text;

    public string Text 
    { 
        get { return _text; } 
        set { _text = value; }
    }

    private float _waitTime;
    private int _currentpage = 1;

    void Start()
    {
        _nextComponent.SetActive(false);
        _waitTime = _speakingTime / _text.ToCharArray().Length;
        _textUI.text = "";
        StartCoroutine(TypeSentence());
    }

    private IEnumerator TypeSentence()
    {
        foreach (char letter in _text.ToCharArray())
        {
            _textUI.text += letter;
            NextPage();
            yield return new WaitForSeconds(_waitTime);
        }
        _nextComponent.SetActive(true);
    }

    private void NextPage()
    {
        if (_currentpage < _textUI.textInfo.pageCount)
        {
            _currentpage++;
            _textUI.pageToDisplay++;
        }
    }
    
}
