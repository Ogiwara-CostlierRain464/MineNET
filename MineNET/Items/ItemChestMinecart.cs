﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Items
{
    public class ItemChestMinecart : Item
    {
        public ItemChestMinecart() : base(ItemFactory.CHEST_MINECART)
        {

        }

        public override string Name
        {
            get
            {
                return "ChestMinecart";
            }
        }
    }
}
