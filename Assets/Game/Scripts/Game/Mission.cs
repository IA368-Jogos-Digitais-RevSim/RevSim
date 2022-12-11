using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mission : MonoBehaviour
{
    [SerializeField] private string _type;
    [SerializeField] private string _title;
    [SerializeField] private float _minimumPower;
    [SerializeField] private string _text;
    [SerializeField] private string _optionA;
    [SerializeField] private string _optionB;
    [SerializeField] private UnityEvent _onOptionA;
    [SerializeField] private UnityEvent _onOptionB;

    private MissionStatus _status;
    private string _statusDescription;

    public string Type { get { return _type; } }
    public string Title { get { return _title; } }
    public string Status { get { return _status.ToDescriptionString(); } }
    public string StatusDescription { get { return _statusDescription; } }
    public string Text { get { return _text; } }
    public string OptionA { get { return _optionA; } }
    public string OptionB { get { return _optionB; } }

    void Update()
    {
        if (_status != MissionStatus.COMPLETED)
        {
            if(GameManager.Instance.PoliticalPower >= _minimumPower)
            {
                _status = MissionStatus.UNLOCKED;
                _statusDescription = "Clique para realizar a missão.";
            }
            else
            {
                _status = MissionStatus.LOCKED;
                _statusDescription = $"É necessario poder politico maior que {_minimumPower}.";
            }
        }
    }

    public bool IsUnlocked()
    {
        return _status == MissionStatus.UNLOCKED;
    }

    public void SelectOptionA()
    {
        _status = MissionStatus.COMPLETED;
        _statusDescription = $"Missão finalizada.";
        _onOptionA.Invoke();
    }

    public void SelectOptionB()
    {
        _status = MissionStatus.COMPLETED;
        _statusDescription = $"Missão finalizada.";
        _onOptionB.Invoke();
    }
}
