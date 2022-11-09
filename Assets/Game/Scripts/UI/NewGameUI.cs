using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Skin;

public class NewGameUI : MonoBehaviour
{
    [SerializeField] private Race _playerRace = Race.BROWN;
    [SerializeField] private Genre _playerGenre = Genre.WOMAN;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_InputField _playerName;
    [SerializeField] private GameObject _messageError;
    private GameObject _objectSkin;

    void Awake()
    {
        _messageError.SetActive(false);
        PlayerSettings.PlayerSkin = (_playerRace, _playerGenre);
        _player.UpdateSkin();
    }

    public void CreateGame()
    {
        if(string.IsNullOrEmpty(_playerName.text))
        {
            _messageError.SetActive(true);
        }
        else
        {
            PlayerSettings.PlayerSkin = (_playerRace, _playerGenre);
            GameController.GoToIntro();
        }
    }
    
    public void ChangeRace(int value)
    {
        if (value != (int)_playerRace)
        {
            _playerRace = (Race)value;
            PlayerSettings.PlayerSkin = (_playerRace, _playerGenre);
            _player.UpdateSkin();
        }
    }

    public void ChangeGenre(int value)
    {
        if (value != (int)_playerGenre)
        {
            _playerGenre = (Genre)value;
            PlayerSettings.PlayerSkin = (_playerRace, _playerGenre);
            _player.UpdateSkin();
        }
    }
}
