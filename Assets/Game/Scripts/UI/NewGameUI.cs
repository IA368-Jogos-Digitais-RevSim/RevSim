using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewGameUI : MonoBehaviour
{
    [SerializeField] private SkinRace _playerSkinRace = SkinRace.BROWN;
    [SerializeField] private SkinGenre _playerSkinGenre = SkinGenre.WOMAN;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_InputField _playerName;
    [SerializeField] private GameObject _messageError;
    private GameObject _objectSkin;

    void Awake()
    {
        _messageError.SetActive(false);
        PlayerSettings.PlayerSkin = (_playerSkinRace, _playerSkinGenre);
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
            PlayerSettings.PlayerSkin = (_playerSkinRace, _playerSkinGenre);
            GameController.GoToIntro();
        }
    }
    
    public void ChangeSkinRace(int value)
    {
        if (value != (int)_playerSkinRace)
        {
            _playerSkinRace = (SkinRace)value;
            PlayerSettings.PlayerSkin = (_playerSkinRace, _playerSkinGenre);
            _player.UpdateSkin();
        }
    }

    public void ChangeSkinGenre(int value)
    {
        if (value != (int)_playerSkinGenre)
        {
            _playerSkinGenre = (SkinGenre)value;
            PlayerSettings.PlayerSkin = (_playerSkinRace, _playerSkinGenre);
            _player.UpdateSkin();
        }
    }
}
