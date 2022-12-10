using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorUI : MonoBehaviour
{
    [SerializeField] private QueueDoorManager _queueDoorManager;
    [SerializeField] private Animator _animatorDoor;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _classeText;
    [SerializeField] private TMP_Text _costMoneyText;
    [SerializeField] private TMP_Text _powerGainText;

    public void OpenDoor()
    {
        var character = _queueDoorManager.FirstCharacter;
        if (character != null)
        {
            _descriptionText.text = character.Description;
            _classeText.text = character.Description;
            _costMoneyText.text = character.CostMoney.ToString();
            _powerGainText.text = character.PowerGain.ToString();
            _panel.SetActive(true);
        }
    }

    public void Accept()
    {
        _panel.SetActive(false);
        _animatorDoor.SetTrigger(ObjectAnimatorParameters.OPEN_DOOR);
        _queueDoorManager.Accept();
    }

    public void Reject()
    {
        _panel.SetActive(false);
        _queueDoorManager.Reject();
    }
}
