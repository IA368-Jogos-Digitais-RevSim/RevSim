using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MemberListUI : MonoBehaviour
{
    [SerializeField] private MembersManager _membersManager;
    [SerializeField] private GameObject _memberUIPrefab;
    [SerializeField] private GameObject _content;
    [SerializeField] private Button _closeButton;

    private List<GameObject> _memberList = new List<GameObject>();

    public void Open(bool isSelectionMode)
    {
        gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(!isSelectionMode);

        foreach (Character character in _membersManager.Members)
        {
            var memberUI = Instantiate(_memberUIPrefab);
            memberUI.transform.SetParent(_content.transform);
            memberUI.transform.localPosition = Vector3.zero;

            memberUI.GetComponent<MemberUI>().UpdateText(character, isSelectionMode);
            _memberList.Add(memberUI);
        }
    }

    public void Open(bool isSelectionMode, System.Action<Character> onSelect)
    {
        gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(!isSelectionMode);

        foreach (Character character in _membersManager.Members)
        {
            var memberUI = Instantiate(_memberUIPrefab);
            memberUI.transform.SetParent(_content.transform);
            memberUI.transform.localPosition = Vector3.zero;

            memberUI.GetComponent<MemberUI>().UpdateText(character, isSelectionMode, ()=>Close(), onSelect);
            _memberList.Add(memberUI);
        }
    }

    public void Close()
    {
        foreach (var member in _memberList.ToList())
        {
            _memberList.Remove(member);
            Destroy(member);
        }
        gameObject.SetActive(false);
    }
}
