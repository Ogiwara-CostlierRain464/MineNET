﻿namespace MineNET.Commands.Parameters
{
    public class CommandParameterValue : CommandParameter
    {
        public CommandParameterValue(string name, bool optional = false, string postfix = null)
            : base(name, CommandParameter.ARG_TYPE_VALUE, optional, null, postfix)
        {

        }
    }
}
