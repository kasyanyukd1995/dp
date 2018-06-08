using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMO
{
    public class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }
        public int IdServicemen { get; set; }
        public int Filtr {get; set;}

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
        

    }
}
