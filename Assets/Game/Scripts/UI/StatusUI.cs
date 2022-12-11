using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _politicalPowerText;

    void Update()
    {
        _moneyText.text = GameManager.Instance.Money.ToString();
        _politicalPowerText.text = GameManager.Instance.PoliticalPower.ToString();
    }
}
