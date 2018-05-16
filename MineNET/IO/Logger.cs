using System;
using System.Collections.Concurrent;

namespace MineNET.IO
{
    public class Logger : ILogger
    {
        public ConcurrentQueue<LoggerData> LoggerQueue { get; } = new ConcurrentQueue<LoggerData>();

        public bool IsRunConsole { get; private set; }

        public InputInterface Input { get; }
        public OutputInterface Output { get; }

        public Logger()
        {
            this.Input = new Input();
            this.Output = new Output(this);
        }

        public void Error(object text)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string time = this.CreateTime();
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = $"§c[Error][{time}] {str}";

                this.AddOueue(str, LoggerLevel.Error);
            }
        }

        public void Error(object text, params object[] args)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = string.Format(str, args);

                this.Error(str);
            }
        }

        public void Fatal(object text)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string time = this.CreateTime();
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = $"§4[Fatal][{time}] {str}";

                this.AddOueue(str, LoggerLevel.Fatal);
            }
        }

        public void Fatal(object text, params object[] args)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = string.Format(str, args);

                this.Fatal(str);
            }
        }

        public void Info(object text)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string time = this.CreateTime();
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = $"§f[Info][{time}] {str}";

                this.AddOueue(str, LoggerLevel.Info);
            }
        }

        public void Info(object text, params object[] args)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = string.Format(str, args);

                this.Info(str);
            }
        }

        public void Log(object text)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string time = this.CreateTime();
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = $"§7[Log][{time}] {str}";

                this.AddOueue(str, LoggerLevel.Log);
            }
        }

        public void Log(object text, params object[] args)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = string.Format(str, args);

                this.Log(str);
            }
        }

        public void Notice(object text)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string time = this.CreateTime();
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = $"§b[Notice][{time}] {str}";

                this.AddOueue(str, LoggerLevel.Notice);
            }
        }

        public void Notice(object text, params object[] args)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = string.Format(str, args);

                this.Notice(str);
            }
        }

        public void Warning(object text)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                string time = this.CreateTime();
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = $"§e[Warning][{time}] {str}";

                this.AddOueue(str, LoggerLevel.Warning);
            }
        }

        public void Warning(object text, params object[] args)
        {
            string str = text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] == '%')
                {
                    string key = str.Remove(0, 1);
                    str = LanguageService.GetString(key);
                }
                str = string.Format(str, args);

                this.Warning(str);
            }
        }

        public void AddOueue(string text, LoggerLevel level)
        {
            LoggerData data = new LoggerData();
            data.Level = level;
            data.Text = text;
            this.LoggerQueue.Enqueue(data);
        }

        private string CreateTime()
        {
            return DateTime.Now.ToString("yyyy/M/d H:mm:ss");
        }

        private string CreateDay()
        {
            return DateTime.Now.ToString("yyyy-M-d");
        }
    }
}
