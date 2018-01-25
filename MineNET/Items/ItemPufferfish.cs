﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Items
{
    class ItemPufferfish : ItemFood
    {
        public ItemPufferfish() : base(ItemFactory.PUFFERFISH)
        {

        }

        public override string Name
        {
            get
            {
                return "Pufferfish";
            }
        }
    }
}
