using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

public class CharacterSettings : MonoBehaviour
{
    public const string CHARACTER_RESOURCE = @"Characters\Classes\Character";

    private static Dictionary<Classe, string> _characterMaterialPath = new Dictionary<Classe, string>
    {
        {Classe.ACTIVIST, @"Characters\Classes\Materials\Activist\Activist"},
        {Classe.COMMUNICATOR, @"Characters\Classes\Materials\Communicator\Communicator"},
        {Classe.DOCTOR, @"Characters\Classes\Materials\Doctor\Doctor"},
        {Classe.NEGOTIATOR, @"Characters\Classes\Materials\Negotiator\Negotiator"},
        {Classe.PARLIAMENTARY, @"Characters\Classes\Materials\Parliamentary\Parliamentary"},
        {Classe.PROGRAMMER, @"Characters\Classes\Materials\Programmer\Programmer"},
        {Classe.WORKER, @"Characters\Classes\Materials\Worker\Worker"}
    };

    private static Dictionary<Race, string> _characterRacePath = new Dictionary<Race, string>
    {
        {Race.BLACK, @"_Black"},
        {Race.BROWN, @"_Brown"},
        {Race.WHITE, @"_White"}
    };

    public static string GetMaterialPath(Classe classe, Race race)
    {
        return _characterMaterialPath.GetValueOrDefault(classe) + _characterRacePath.GetValueOrDefault(race);
    }

    public static string GetMaterialPath(Classe classe)
    {
        return GetMaterialPath(classe, (Race) Random.Range(0, 2));
    }
}
