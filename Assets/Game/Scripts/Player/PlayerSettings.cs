using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public static class PlayerSettings
{
    public const string PLAYER_RESOURCE = @"Characters\Player\Player";

    private static Dictionary<(Race, Genre), string> _playerMaterialPath = new Dictionary<(Race, Genre), string>
    {
        {(Race.BLACK, Genre.WOMAN), @"Characters\Player\Materials\Player_Woman_Black"},
        {(Race.BROWN, Genre.WOMAN), @"Characters\Player\Materials\Player_Woman_Brown"},
        {(Race.WHITE, Genre.WOMAN), @"Characters\Player\Materials\Player_Woman_White"},
        {(Race.BLACK, Genre.MAN), @"Characters\Player\Materials\Player_Man_Black"},
        {(Race.BROWN, Genre.MAN), @"Characters\Player\Materials\Player_Man_Brown"},
        {(Race.WHITE, Genre.MAN), @"Characters\Player\Materials\Player_Man_White"}
    };

    public static (Race race, Genre genre) PlayerSkin = (Race.BROWN, Genre.WOMAN);

    public static string GetPlayerMaterialPath(Race race, Genre genre)
    {
        return _playerMaterialPath.GetValueOrDefault((race, genre));
    }

    public static string GetPlayerMaterialPath()
    {
        return GetPlayerMaterialPath(PlayerSkin.race, PlayerSkin.genre);
    }

}
