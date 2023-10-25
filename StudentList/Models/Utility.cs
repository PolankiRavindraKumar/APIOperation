using System.Runtime.CompilerServices;

namespace StudentList.Models
{
    public class Utility
    {
       public static string GetConnection()
        {
            return "Data source=POLANKI\\POLANKISQL2022; initial catalog=Practice; integrated security=sspi;";
        }
    }
}
