using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent
{
    class clsButton
    {
        public int Counter { get; set; }
        public clsButton(int Counter)
        {
            this.Counter=Counter;
        }

    }
    class clsClickButton
    {
        public event EventHandler<clsButton> ClickedButton;
        public void OnClicButton(ref int increment)
        {
            increment++;
            OnClickButton(new clsButton(increment));
        }
        protected virtual void OnClickButton(clsButton button)
        {
            ClickedButton?.Invoke(this, button);
        }
    }
    class clsSubscribe
    {
        public void Subscribe(clsClickButton Clickbutton)
        {
            Clickbutton.ClickedButton += HandleCounter;
        }
        private void HandleCounter(object sender,clsButton button)
        {
            Console.WriteLine($"Counter={button.Counter}");
            Console.ReadLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            clsClickButton clisckButton = new clsClickButton();
            clsSubscribe subscribe = new clsSubscribe();
            subscribe.Subscribe(clisckButton);
            int counter = 0;
            clisckButton.OnClicButton(ref counter);
            clisckButton.OnClicButton(ref counter);
            clisckButton.OnClicButton(ref counter);
            clisckButton.OnClicButton(ref counter);
            clisckButton.OnClicButton(ref counter);
            clisckButton.OnClicButton(ref counter);
            clisckButton.OnClicButton(ref counter);
        }
    }
}
