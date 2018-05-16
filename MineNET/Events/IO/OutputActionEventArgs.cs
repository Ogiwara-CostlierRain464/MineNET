using System;

namespace MineNET.Events.IO
{
    public class OutputActionEventArgs : EventArgs
    {
        public string OutputText { get; set; }

        public OutputActionEventArgs(string text)
        {
            this.OutputText = text;
        }
    }
}
