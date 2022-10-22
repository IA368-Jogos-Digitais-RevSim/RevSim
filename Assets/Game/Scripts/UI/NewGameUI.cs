using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewGameUI : MonoBehaviour
{
    [SerializeField] private SkinRace _playerSkinRace = SkinRace.BROWN;
    [SerializeField] private SkinGenre _playerSkinGenre = SkinGenre.FEMALE;
    [SerializeField] private Transform _spawn;
    [SerializeField] private TMP_InputField _playerName;
    [SerializeField] private GameObject _messageError;
    [SerializeField] private string _startScene = "Base1";
    private GameObject _objectSkin;

    void Awake()
    {
        _messageError.SetActive(false);
        UpdateSkin();
    }

    public void CreateGame()
    {
        if(string.IsNullOrEmpty(_playerName.text))
        {
            _messageError.SetActive(true);
        }
        else
        {
            GameController.GoToScene(_startScene);
        }
    }

    private void UpdateSkin()
    {
        string path = PlayerSettings.GetPlayerSkinPath(_playerSkinRace, _playerSkinGenre);
        Destroy(_objectSkin);
        _objectSkin = (GameObject)Instantiate(Resources.Load(path), _spawn);
    }
    
    public void ChangeSkinRace(int value)
    {
        if (value != (int)_playerSkinRace)
        {
            _playerSkinRace = (SkinRace)value;
            UpdateSkin();
        }
    }

    public void ChangeSkinGenre(int value)
    {
        if (value != (int)_playerSkinGenre)
        {
            _playerSkinGenre = (SkinGenre)value;
            UpdateSkin();
        }
    }
}
