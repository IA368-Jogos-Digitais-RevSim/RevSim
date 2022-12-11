using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MemberUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _classeText;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private Button _selectButton;

    public void UpdateText(Character character, bool isSelectionMode)
    {
        _classeText.text = character.Classe.ToDescriptionString();
        _hpText.text = character.HP.ToString();
        _statusText.text = character.Status.ToDescriptionString();
        _selectButton.gameObject.SetActive(isSelectionMode);
    }

    public void UpdateText(Character character, bool isSelectionMode, System.Action close, System.Action<Character> onSelect)
    {
        UpdateText(character, isSelectionMode);

        _selectButton.onClick.AddListener(
            () => 
            { 
                onSelect(character); 
                close(); 
            }
        );
    }
}
