using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private Mission _mission;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _typeText;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private TMP_Text _statusDescriptionText;
    [SerializeField] private float _dialogueSpeed = 0.07f;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Button _optionA;
    [SerializeField] private Button _optionB;

    private int _currentpage = 1;

    void Awake()
    {
        _typeText.text = _mission.Type;
        _titleText.text = _mission.Title;
    }

    void Update()
    {
        _button.interactable = _mission.IsUnlocked();
        _statusText.text = _mission.Status;
        _statusDescriptionText.text = _mission.StatusDescription;
    }

    public void OpenMission()
    {
        _optionA.GetComponentInChildren<TMP_Text>().text = _mission.OptionA;
        _optionA.onClick.AddListener( () => SelectOptionA() );

        _optionB.GetComponentInChildren<TMP_Text>().text = _mission.OptionB;
        _optionB.onClick.AddListener( () => SelectOptionB() );

        _dialoguePanel.SetActive(true);
        StartCoroutine(TypeSentence());
    }

    public void SelectOptionA()
    {
        _dialoguePanel.SetActive(false);
        _mission.SelectOptionA();
    }

    public void SelectOptionB()
    {
        _dialoguePanel.SetActive(false);
        _mission.SelectOptionB();
    }

    private IEnumerator TypeSentence()
    {
        _dialogueText.text = "";
        foreach (char letter in _mission.Text.ToCharArray())
        {
            _dialogueText.text += letter;
            NextPage();
            yield return new WaitForSeconds(_dialogueSpeed);
        }
    }

    private void NextPage()
    {
        if (_currentpage < _dialogueText.textInfo.pageCount)
        {
            _currentpage++;
            _dialogueText.pageToDisplay++;
        }
    }
}
