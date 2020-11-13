using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppKodeRefactoring
{
    class Ui
    {
        public void ContinueProcess(string whatToDo)
        {
            Console.WriteLine($"press any key to {whatToDo}...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
