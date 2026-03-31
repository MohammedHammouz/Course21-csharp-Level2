using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewEvents
{
    public class TempretureChangedArgs : EventArgs
    {
        public int OldTemp { get; }
        public int NewTemp { get;}
        public int DiffTemps { get; }
        public TempretureChangedArgs(int OldTemp,int NewTemp)
        {
            this.OldTemp = OldTemp;
            this.NewTemp = NewTemp;
            this.DiffTemps = this.NewTemp - this.OldTemp;
        }
    }
    public class Thermostat
    {
        public event EventHandler<TempretureChangedArgs> ChangeTempreture;
        public int OldTemp;
        public int CurrentTemp;
        public void setTempreture(int NewTemp)
        {
            if (NewTemp != CurrentTemp)
            {
                OldTemp = CurrentTemp;
                CurrentTemp = NewTemp;
                OnTempretureChanged(OldTemp, CurrentTemp);
            }
        }
        private void OnTempretureChanged(int OldTemp,int CurrTemp)
        {
            OnTempretureChanged(new TempretureChangedArgs(OldTemp,CurrTemp));
        }
        protected virtual void OnTempretureChanged(TempretureChangedArgs e)
        {
            ChangeTempreture?.Invoke(this, e);
        }
    }
    public class Display {
        

    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
