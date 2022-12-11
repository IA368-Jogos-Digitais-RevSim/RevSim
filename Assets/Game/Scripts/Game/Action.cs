using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;
using System.Linq;

public class Action : MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private float _reward;
    [SerializeField] private float _punishment;
    [SerializeField] private Classe[] _classeWithBonus;
    [SerializeField] private float _chancePerMember;
    [SerializeField] private float _bonusPercentage;
    [SerializeField] private float _timeRunning;
    
    public float ChanceOfSuccess { get; private set; }
    public bool IsRunning { get; private set; }
    public float PercentageToComplete { get; private set; }
    public bool Success { get; private set; }

    private Character[] _allocatedMembers = new Character[3];

    #region Get Properties
    public string Title { get { return _title; } }
    public float Reward { get { return _reward; } }
    public float Punishment { get { return _punishment; } }
    public float BonusPercentage { get { return _bonusPercentage; } }
    public Classe[] ClasseWithBonus { get { return _classeWithBonus; } }
    public Character[] AllocatedMembers { get { return _allocatedMembers; } }
    #endregion

    void Update()
    {
        CheckMembers();
        UpdateChanceOfSuccess();
    }

    public bool IsUnlocked()
    {
        return ChanceOfSuccess > 0;
    }

    private void UpdateChanceOfSuccess()
    {
        float chance = 0;
        foreach (var character in _allocatedMembers)
        {
            if (character != null)
            {
                chance += _classeWithBonus.Any(_ => _ == character.Classe) 
                    ? (_chancePerMember + _chancePerMember*(_bonusPercentage/100)) : _chancePerMember;
            }
        }
        ChanceOfSuccess = chance > 100 ? 100 : chance;
    }

    private void CheckMembers()
    {
        for (int i = 1; i < _allocatedMembers.Length-1; i++)
        {
            if (_allocatedMembers[i] != null && _allocatedMembers[i].Action != this && _allocatedMembers[i].Status != CharacterStatus.AVAILABLE)
            {
                _allocatedMembers[i] = null;
            }
        }
    }

    private void RemoveCharacter(Character character)
    {
        for (int i = 0; i < _allocatedMembers.Length; i++)
        {
            if (_allocatedMembers[i] == character)
            {
                _allocatedMembers[i] = null;
            }
        }
    }

    public void SetMemberOne(Character character)
    {
        RemoveCharacter(character);
        _allocatedMembers[0] = character;
    }

    public void SetMemberTwo(Character character)
    {
        RemoveCharacter(character);
        _allocatedMembers[1] = character;
    }

    public void SetMemberThree(Character character)
    {
        RemoveCharacter(character);
        _allocatedMembers[2] = character;
    }

    public void StartAction()
    {
        foreach (var character in _allocatedMembers.ToList())
        {
            if (character != null)
            {
                character.StartAction(this);
            }
        }

        StartCoroutine(Running());
    }

    public void Complete()
    {
        if (Success)
            GameManager.Instance.Money += Reward;
        else
            GameManager.Instance.Money -= Punishment;

        IsRunning = false;
        PercentageToComplete = 0;
        for (int i = 0; i < _allocatedMembers.Length; i++)
        {
            if (_allocatedMembers[i] != null)
            {
                _allocatedMembers[i].EndAction();
                _allocatedMembers[i] = null;
            }
        }
    }

    IEnumerator Running()
    {
        var Success = Random.Range(0f, 1f) < (ChanceOfSuccess / 100);

        IsRunning = true;
        var time = 0;
        do
        {
            PercentageToComplete = (time * 100) / _timeRunning;
            yield return new WaitForSeconds(1);
            time++;
        } while(PercentageToComplete < 100);
    }
}
