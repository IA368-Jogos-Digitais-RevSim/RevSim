using System.ComponentModel;

public enum MissionStatus
{
    [Description("Bloqueada")]
    LOCKED, 

    [Description("Desbloqueada")]
    UNLOCKED, 

    [Description("Completa")]
    COMPLETED
}