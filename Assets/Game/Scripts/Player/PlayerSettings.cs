using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkinRace
{
    BLACK, BROWN, WHITE
}

public enum SkinGenre
{
    WOMAN, MAN
}

public static class PlayerSettings
{
    public const string PLAYER_RESOURCE = @"Characters\Player\Player";

    private static Dictionary<(SkinRace, SkinGenre), string> _playerMaterialPath = new Dictionary<(SkinRace, SkinGenre), string>
    {
        {(SkinRace.BLACK, SkinGenre.WOMAN), @"Characters\Player\Materials\Player_Woman_Black"},
        {(SkinRace.BROWN, SkinGenre.WOMAN), @"Characters\Player\Materials\Player_Woman_Brown"},
        {(SkinRace.WHITE, SkinGenre.WOMAN), @"Characters\Player\Materials\Player_Woman_White"},
        {(SkinRace.BLACK, SkinGenre.MAN), @"Characters\Player\Materials\Player_Man_Black"},
        {(SkinRace.BROWN, SkinGenre.MAN), @"Characters\Player\Materials\Player_Man_Brown"},
        {(SkinRace.WHITE, SkinGenre.MAN), @"Characters\Player\Materials\Player_Man_White"}
    };

    public static (SkinRace race, SkinGenre genre) PlayerSkin = (SkinRace.BROWN, SkinGenre.WOMAN);

    public static string GetPlayerMaterialPath(SkinRace race, SkinGenre genre)
    {
        return _playerMaterialPath.GetValueOrDefault((race, genre));
    }

    public static string GetPlayerMaterialPath()
    {
        return GetPlayerMaterialPath(PlayerSkin.race, PlayerSkin.genre);
    }

}
