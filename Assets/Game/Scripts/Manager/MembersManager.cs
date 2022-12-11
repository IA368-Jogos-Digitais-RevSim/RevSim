using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MembersManager : MonoBehaviour
{
    [SerializeField] private Character[] _firstMembers;
    [SerializeField] private Transform[] _positions;

    public List<Character> Members { get; private set; }

    void Awake()
    {
        Members = new List<Character>(_firstMembers);
        UpdatePositions();
    }

    public void AddMember(Character character)
    {
        Members.Add(character);
        UpdatePositions();
    }

    void UpdatePositions()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            if (Members.Count() >= i+1)
            {
                Members[i].GoToChair(_positions[i].position);
            }
        }
    }
}
