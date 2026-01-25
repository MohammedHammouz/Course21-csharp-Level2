using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDelegation
{
    public class ReadWord
    {
        public delegate void WordDelegation(string word);
        private WordDelegation _Word;
        public WordDelegation Word;
        public ReadWord(WordDelegation Word)
        {
            _Word = Word;
        }
        public void PrintWordInformation(string word)
        {
                _Word(word);
           

        }
        public void PrintWordInformation2(string word)
        {
            
                Word(word);
        }
    }
    internal class Program
    {
        public static void PrintWordCard(string word)
        {
            Console.WriteLine("-----------Word Information-----------");
            Console.WriteLine($"The word is : {word}");
            Console.WriteLine($"length of word: { word.Count()}");
            Console.WriteLine("-------------------------------------");
        }
        public static void PrintWord(string word)
        {
            
            Console.WriteLine($"The word is : {word}");
            
        }
        public static void PrintWordSize(string word)
        {

            Console.WriteLine($"length of word: {word.Count()}");

        }
        static void Main(string[] args)
        {

            ReadWord word = new ReadWord(PrintWordCard);
            
            word.PrintWordInformation("Mohammed");
            word.Word += PrintWord;
            word.Word += PrintWordSize;
            word.PrintWordInformation2("Mohammed Said Hammouz");
        }
    }
}
