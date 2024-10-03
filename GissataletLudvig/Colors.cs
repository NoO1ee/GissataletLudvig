using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GissataletLudvig;

class CO()
{
    public static string Green(string v)
    {
        return $"\x1b[32;3m{v}\x1b[0m";
    }

    public static string Yellow(string v)
    {
        return $"\x1b[33;3m{v}\x1b[0m";
    }
    public static string Red(string v)
    {
        return $"\x1b[31;3m{v}\x1b[0m";
    }
    public static string Blue(string v)
    {
        return $"\x1b[34;3m{v}\x1b[0m";
    }
    public static string Magenta(string v)
    {
        return $"\x1b[35;3m{v}\x1b[0m";
    }
    public static string Cyan(string v)
    {
        return $"\x1b[36;3m{v}\x1b[0m";
    }
    public static string White(string v)
    {
        return $"\x1b[37;3m{v}\x1b[0m";
    }
}