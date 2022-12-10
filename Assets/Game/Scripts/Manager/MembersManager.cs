using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MembersManager : MonoBehaviour
{
    [SerializeField] private Character[] _firstMembers;
    [SerializeField] private Transform[] _positions;

    private List<Character> _members;

    void Awake()
    {
        _members = new List<Character>(_firstMembers);
        UpdatePositions();
    }

    public void AddMember(Character character)
    {
        _members.Add(character);
        UpdatePositions();
    }

    void UpdatePositions()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            if (_members.Count() >= i+1)
            {
                _members[i].GoToChair(_positions[i].position);
            }
        }
    }
}
