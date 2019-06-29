using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    public enum Language
    {
        English,
        French,
        Japanese,
        Korean,
        Unknown
    }
    public enum TypeMedia
    {
        Movie,
        Series,
        Unknown
    }

    public enum TypePerson
    {
        Friend,
        Other
    }

    public enum PersonTitle
    {
        Mme,
        Mlle,
        Mr,
        Unknown
    }

    public enum PersonMediaFunction
    {
        Actor,
        Director,
        Producer,
        Unknown
    }
}
