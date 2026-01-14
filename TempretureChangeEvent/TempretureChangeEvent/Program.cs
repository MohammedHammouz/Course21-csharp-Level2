using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static TempretureChangeEvent.Program;

namespace TempretureChangeEvent
{
    public class Program
    {
        public class clsTempreture{
            public double OldTempreture
            {
                get;
            }
            public double NewTempreture
            {
                get; 
            }
            public double Diff
            {
                get; 
            }
            public clsTempreture(double OldTempreture,double NewTempreture)
            {
                this.OldTempreture = OldTempreture;
                this.NewTempreture = NewTempreture;
                this.Diff = this.NewTempreture - this.OldTempreture;
            }
        }
        public class clsThermostat
        {
            private double OldTempreture;
            private double CurrentTempreture;
            public event EventHandler<clsTempreture> Changed;
            private void OnTempretureChanged(double OldTempreture, double NewTempreture)
            {
                OnTempretureChanged(new clsTempreture(OldTempreture, NewTempreture));
            }
            protected virtual void OnTempretureChanged(clsTempreture e)
            {
                Changed?.Invoke(this, e);
            }
            public void SetTempreture(int NewTempreture)
            {
                OldTempreture = CurrentTempreture;
                if(CurrentTempreture != NewTempreture)
                {
                    CurrentTempreture = NewTempreture;
                    OnTempretureChanged(OldTempreture,NewTempreture);
                }

            }
        }
        public class Display
        {
            public void Subscribe(clsThermostat thermostat)
            {
                thermostat.Changed += ShowTempreture;
            }
            private void ShowTempreture(object sender,clsTempreture tempreture)
            {
                Console.WriteLine("\n\nTempreture changed");
                Console.WriteLine($"Old Tempreture:{tempreture.OldTempreture}");
                Console.WriteLine($"New Tempreture:{tempreture.NewTempreture}");
                Console.WriteLine($"Diff Tempreture:{tempreture.Diff}");
            }
        }
        static void Main(string[] args)
        {
            clsThermostat thermostat = new clsThermostat();
            Display display=new Display();
            display.Subscribe(thermostat);
            thermostat.SetTempreture(25);
            thermostat.SetTempreture(25);
            thermostat.SetTempreture(555);
            
            
            


        }
    }
}
