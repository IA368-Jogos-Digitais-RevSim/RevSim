using System.ComponentModel;

namespace Skin
{
    public enum Race
    {
        BLACK, BROWN, WHITE
    }

    public enum Genre
    {
        WOMAN, MAN
    }

    public enum Classe
    {
        [Description("Ativista")]
        ACTIVIST, 

        [Description("Comunicador")]
        COMMUNICATOR, 

        [Description("Médico")]
        DOCTOR, 

        [Description("Negociador")]
        NEGOTIATOR, 

        [Description("Parlamentar")]
        PARLIAMENTARY, 

        [Description("Programador")]
        PROGRAMMER, 

        [Description("Trabalhador")]
        WORKER
    }
}

