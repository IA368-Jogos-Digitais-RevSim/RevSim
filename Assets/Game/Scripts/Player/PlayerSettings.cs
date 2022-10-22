using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkinRace
{
    BLACK, BROWN, WHITE
}

public enum SkinGenre
{
    FEMALE, MALE
}

public class PlayerSettings : MonoBehaviour
{
    private static Dictionary<(SkinRace, SkinGenre), string> _playerSkinResources = new Dictionary<(SkinRace, SkinGenre), string>
    {
        {(SkinRace.BLACK, SkinGenre.FEMALE), @"Characters\Player\Female\Player_Female_Black"},
        {(SkinRace.BROWN, SkinGenre.FEMALE), @"Characters\Player\Female\Player_Female_Brown"},
        {(SkinRace.WHITE, SkinGenre.FEMALE), @"Characters\Player\Female\Player_Female_White"},
        {(SkinRace.BLACK, SkinGenre.MALE), @"Characters\Player\Male\Player_Male_Black"},
        {(SkinRace.BROWN, SkinGenre.MALE), @"Characters\Player\Male\Player_Male_Brown"},
        {(SkinRace.WHITE, SkinGenre.MALE), @"Characters\Player\Male\Player_Male_White"}
    };

    public PlayerSettings()
    {

    }

    public static string GetPlayerSkinPath(SkinRace race, SkinGenre genre)
    {
        return _playerSkinResources.GetValueOrDefault((race, genre));
    }

}
