using System;
using System.ComponentModel;

namespace Playground.Common
{
    public class Counter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int value;

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        public void Increment()
        {
            Value++;
        }

        public void Decrement()
        {
            Value--;
        }

        public void Reset()
        {
            Value = 0;
        }
    }
}
