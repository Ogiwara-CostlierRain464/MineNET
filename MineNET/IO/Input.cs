﻿using MineNET.Commands;
using MineNET.Events.IOEvents;
using System;
using System.Threading;

namespace MineNET.IO
{
    public sealed class Input : InputInterface
    {
        public Thread InputThread { get; private set; }

        public bool IsRunning { get; private set; }
        public bool UsingGUI { get; private set; }

        public Input()
        {
            try
            {
                Console.Write(string.Empty);
            }
            catch
            {
                this.UsingGUI = true;
                return;
            }
            this.IsRunning = true;

            this.InputThread = new Thread(this.OnUpdate);
            this.InputThread.Name = "InputThread";
            this.InputThread.Start();
        }

        public void InputAction(string inputText)
        {
            CommandData data = new CommandData(new ConsoleCommandSender());
            data.Text = inputText;
            Server.Instance.Command.CommandHandler.OnCommandExecute(data);
        }

        public void Dispose()
        {
            this.IsRunning = false;

            this.InputThread = null;
        }

        private void OnUpdate()
        {
            while (this.IsRunning)
            {
                string inputText = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inputText))
                {
                    InputActionEventArgs ev = new InputActionEventArgs(inputText);
                    Server.Instance.Event.IO.OnInputAction(this, ev);
                    this.InputAction(ev.InputText);
                }
            }
        }
    }
}
