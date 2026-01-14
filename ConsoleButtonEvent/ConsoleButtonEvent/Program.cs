using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleButtonEvent
{
    class clsConsoleButton
    {
        public string ButtonName {
            get;set;
        }
        public clsConsoleButton(string ButtonName) { 
            this.ButtonName= ButtonName;
        }
    }
    class clsGetConsole
    {
        public EventHandler<clsConsoleButton> ConsolingButton;
        
        public void OnConsoleButton(string ButtonName)
        {
            OnConsoleButton(new clsConsoleButton(ButtonName));
        }
        protected void OnConsoleButton(clsConsoleButton button)
        {
            ConsolingButton?.Invoke(this, button);
        }
    }
    class clsSubscribe
    {
        public void Subscribe(clsGetConsole console)
        {
            console.ConsolingButton += HandleButton;
        }
        public void UnSubscribe(clsGetConsole console)
        {
            console.ConsolingButton -= HandleButton;
        }
        private void HandleButton(object sender, clsConsoleButton consoleButton)
        {
            Console.WriteLine($"Button name:{consoleButton.ButtonName}");
            Console.ReadLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            clsGetConsole consoleButton = new clsGetConsole();
            clsSubscribe subscribe = new clsSubscribe();
            subscribe.Subscribe(consoleButton);
            consoleButton.OnConsoleButton("Mohammed");
            consoleButton.OnConsoleButton("Ahmed");
            consoleButton.OnConsoleButton("Ahmed1");
            consoleButton.OnConsoleButton("Ahmed2");
            consoleButton.OnConsoleButton("Ahmed3");
            consoleButton.OnConsoleButton("Ahmed4");
            consoleButton.OnConsoleButton("Ahmed5");
            subscribe.UnSubscribe(consoleButton);
            consoleButton.OnConsoleButton("Ahmed5");
            consoleButton.OnConsoleButton("Ahmed4");
            consoleButton.OnConsoleButton("Ahmed3");
            consoleButton.OnConsoleButton("Ahmed2");
            consoleButton.OnConsoleButton("Ahmed1");
            Console.ReadLine();
        }
    }
}
