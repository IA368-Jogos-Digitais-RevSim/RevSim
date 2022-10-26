using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawn;
    private GameObject _player;
    
    void Awake()
    {
        // Instantiate the player
        _player = (GameObject)Instantiate(Resources.Load(PlayerSettings.GetPlayerSkinPath()), _playerSpawn);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
