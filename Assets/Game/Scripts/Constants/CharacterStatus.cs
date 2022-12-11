using System.ComponentModel;

public enum CharacterStatus
{
    [Description("Disponível")]
    AVAILABLE,

    [Description("Em Missão")]
    ON_MISSION, 

    [Description("Incapacitado")]
    INCAPACITATED
}