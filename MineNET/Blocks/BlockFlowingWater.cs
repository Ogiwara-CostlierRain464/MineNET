﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Blocks
{
    public class BlockFlowingWater : Block
    {
        public BlockFlowingWater() : base(BlockFactory.FLOWING_WATER)
        {

        }

        public override string Name
        {
            get
            {
                return "FlowingWater";
            }
        }
    }
}
