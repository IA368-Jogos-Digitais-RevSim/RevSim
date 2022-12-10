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

    public void Accept()
    {
        _characters.Remove(FirstCharacter);
        _membersManager.AddMember(FirstCharacter);
        FirstCharacter = _characters.AsQueryable().FirstOrDefault();
        UpdatePositions();
    }

    public void Reject()
    {
        _characters.Remove(FirstCharacter);
        Destroy(FirstCharacter);
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
