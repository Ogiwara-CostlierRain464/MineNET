﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Items
{
    public class ItemShulkerShell : Item
    {
        public ItemShulkerShell() : base(ItemFactory.SHULKER_SHELL)
        {

        }

        public override string Name
        {
            get
            {
                return "ShulkerShell";
            }
        }
    }
}
