﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Items
{
    class ItemBeetrootSeed : Item
    {
        public ItemBeetrootSeed() : base(ItemFactory.BEETROOT_SEEDS)
        {

        }

        public override string Name
        {
            get
            {
                return "BeetrootSeed";
            }
        }
    }
}
