using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    /// <summary>
    /// this is lesson about how using Generic class
    /// </summary>
    /// <typeparam name="T">content1</typeparam>
    /// <typeparam name="T1">content2</typeparam>
    public class GenericBox<T,T1>
    {
        private T content1;
        private T1 content2;
        public GenericBox(T content1,T1 content2)
        {
            this.content1 = content1;
            this.content2 = content2;
        }
        public T GetContent1()
        {
            return this.content1;
        }
        public T1 GetContent2()
        {
            return this.content2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericBox<int, string> genericBox = new GenericBox<int, string>(31, "Mohammed Hammouz");
            Console.WriteLine($"Content of genericbox content1 = {genericBox.GetContent1()},content2 = {genericBox.GetContent2()}");
            GenericBox<float, float> floatBox = new GenericBox<float, float>(2.1f, 3.4f);
            Console.WriteLine($"Content of floatbox content1 = {floatBox.GetContent1()},content2 = {floatBox.GetContent2()}");
        }
    }
}
