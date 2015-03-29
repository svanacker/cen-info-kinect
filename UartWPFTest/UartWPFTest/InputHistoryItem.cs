using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartWPFTest
{
    public class InputHistoryItem
    {
        public string Text { get; private set; }

        public int Counter { get; private set; }

        public InputHistoryItem(string text)
        {
            Text = text;
        }

        public void IncCounter()
        {
            Counter++;
        }
    }
}
