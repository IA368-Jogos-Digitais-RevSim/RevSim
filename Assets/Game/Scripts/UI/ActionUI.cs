using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    [SerializeField] private MemberListUI _memberListUI;
    [SerializeField] private GameObject[] _members;
    [SerializeField] private Action _action;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _rewardText;
    [SerializeField] private TMP_Text _punishmentText;
    [SerializeField] private TMP_Text _chanceOfSuccessText;
    [SerializeField] private TMP_Text _bonusDescriptionText;
    [SerializeField] private TMP_Text _warnText;
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Image _loadingBar;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private Button _buttonComplete;

    void Awake()
    {
        _titleText.text = _action.Title;
        _rewardText.text = $"Ganha {_action.Reward} de Poder Politico.";
        _punishmentText.text = $"Perde {_action.Punishment} de Poder Político.";
        _bonusDescriptionText.text = _action.ClasseWithBonus.Length > 0 
            ? $"Bônus de {_action.BonusPercentage}% para classes {ClassesToString()}." : string.Empty;
    }

    void Update()
    {
        _chanceOfSuccessText.text = $"{_action.ChanceOfSuccess}%";
        _buttonStart.interactable = _action.IsUnlocked();
        _warnText.gameObject.SetActive(!_action.IsUnlocked());
        UpdateMembers();

        if (_action.IsRunning)
            UpdateRunning();
    }

    public void SelectMember(int position)
    {
        switch (position)
        {
            case 1:
                _memberListUI.Open(true, _action.SetMemberOne);
                break;
            case 2:
                _memberListUI.Open(true, _action.SetMemberTwo);
                break;
            case 3:
                _memberListUI.Open(true, _action.SetMemberThree);
                break;
            default:
                break;
        }
    }

    public void StartAction()
    {
        _buttonComplete.transform.parent.gameObject.SetActive(true);
        _buttonComplete.gameObject.SetActive(false);
        _action.StartAction();
    }

    public void Complete()
    {
        _action.Complete();
        _buttonComplete.transform.parent.gameObject.SetActive(false);
    }

    private string ClassesToString()
    {
        string result = string.Empty;
        var classes = _action.ClasseWithBonus;

        if (classes.Length == 1)
            result = classes[0].ToDescriptionString();
        else
        {
            result = classes[0].ToDescriptionString();
            for (int i = 1; i < classes.Length-1; i++)
            {
                result += $", {classes[0].ToDescriptionString()}";
            }
            result += $" ou {classes[classes.Length-1].ToDescriptionString()}";
        }

        return result;
    }

    private void UpdateMembers()
    {
        for (int i = 0; i < _action.AllocatedMembers.Length; i++)
        {
            Character character = _action.AllocatedMembers[i];
            if (character != null)
            {
                _members[i].GetComponentInChildren<TMP_Text>().text = character.Classe.ToDescriptionString();
            }
            else
            {
                _members[i].GetComponentInChildren<TMP_Text>().text = "Selecione";
            }
        }
    }

    private void UpdateRunning()
    {
        _loadingBar.fillAmount = _action.PercentageToComplete / 100;
        _loadingText.text = $"{_action.PercentageToComplete}%";

        if (_action.PercentageToComplete == 100)
        {
            _buttonComplete.gameObject.SetActive(true);
            _statusText.text = _action.Success ? "Sucesso!" : "Falhou!";
        }
    }
}
