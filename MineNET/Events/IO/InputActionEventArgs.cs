using System;

namespace MineNET.Events.IO
{
    public class InputActionEventArgs : EventArgs
    {
        public string InputText { get; set; }

        public InputActionEventArgs(string outputText)
        {
            this.InputText = outputText;
        }
    }
}
