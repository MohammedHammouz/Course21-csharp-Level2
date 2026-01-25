using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsDelegation
{
    public class ReadOperation
    {
        public delegate void OperationType(int num1, char OperationType, int num2);
        private OperationType _Operation;
        public OperationType Operation;
        public ReadOperation(OperationType Operation)
        {
            _Operation = Operation;
            
        }
        public void PrintResult(int num1, char OperationType, int num2)
        {
            _Operation(num1,OperationType,num2);
            Operation(num1, OperationType, num2);
        }
    }
    internal class Program
    {    
        public static void ChoosingOperation(int num1,char OperationType,int num2)
         {
            if (OperationType == '*')
                Console.WriteLine(num1 * num2);
            else if (OperationType == '/')
                Console.WriteLine(num1 / num2);
            else if (OperationType == '+')
                Console.WriteLine(num1 + num2);
            else if (OperationType == '-')
                Console.WriteLine(num1 - num2);
        }
        static void Main(string[] args)
        {
            ReadOperation read = new ReadOperation(ChoosingOperation);
            read.Operation += ChoosingOperation;
            read.PrintResult(20, '+', 10);
            read.PrintResult(20, '-', 10);
            Console.ReadLine();
        }
    }
}
