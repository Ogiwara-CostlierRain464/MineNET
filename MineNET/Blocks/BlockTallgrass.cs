﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Blocks
{
    public class BlockTallgrass : Block
    {
        public BlockTallgrass() : base(BlockFactory.TALLGRASS)
        {

        }

        public override string Name
        {
            get
            {
                return "Tallgrass";
            }
        }
    }
}
