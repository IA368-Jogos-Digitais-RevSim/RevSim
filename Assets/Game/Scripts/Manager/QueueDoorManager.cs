using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QueueDoorManager : MonoBehaviour
{
    [SerializeField] private Character[] FirstCharacters;
    [SerializeField] private Transform[] _positions;
    [SerializeField] private MembersManager _membersManager;

    private List<Character> _characters;
    public Character FirstCharacter { get; private set; }

    void Awake()
    {
        _characters = new List<Character>(FirstCharacters);
        FirstCharacter = _characters.AsQueryable().FirstOrDefault();
    }

    public bool Accept()
    {
        if (GameManager.Instance.Money >= FirstCharacter.CostMoney)
        {
            GameManager.Instance.Money -= FirstCharacter.CostMoney;
            GameManager.Instance.PoliticalPower += FirstCharacter.PowerGain;

            _characters.Remove(FirstCharacter);
            _membersManager.AddMember(FirstCharacter);
            FirstCharacter = _characters.AsQueryable().FirstOrDefault();

            UpdatePositions();

            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reject()
    {
        _characters.Remove(FirstCharacter);
        Destroy(FirstCharacter.gameObject);
        FirstCharacter = _characters.AsQueryable().FirstOrDefault();
        UpdatePositions();
    }

    void UpdatePositions()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            if (_characters.Count() >= i+1)
            {
                _characters[i].GoToTarget(_positions[i].position);
            }
        }
    }
}
