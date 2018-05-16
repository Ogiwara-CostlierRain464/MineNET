using System;
using System.Threading;
using MineNET.Events.IO;

namespace MineNET.IO
{
    public sealed class Input : InputInterface, IDisposable
    {
        public Thread InputThread { get; private set; }

        public bool IsRunning { get; private set; }
        public bool UsingGUI { get; private set; }

        public event EventHandler<InputActionEventArgs> Action;
        private void OnAction(object sender, InputActionEventArgs e)
        {
            this.Action?.Invoke(sender, e);
        }

        public Input()
        {
            try
            {
                Console.Write("");
            }
            catch
            {
                this.UsingGUI = true;
                return;
            }
            this.IsRunning = true;

            this.InputThread = new Thread(this.OnUpdate);
            this.InputThread.Start();
        }

        public void InputAction(string inputText)
        {

        }

        public void Dispose()
        {
            this.IsRunning = false;

            this.InputThread?.Join();
            this.InputThread = null;
        }

        private void OnUpdate()
        {
            while (this.IsRunning)
            {
                string inputText = Console.ReadLine();
                this.OnAction(this, new InputActionEventArgs(inputText));
                this.InputAction(inputText);
            }
        }
    }
}
