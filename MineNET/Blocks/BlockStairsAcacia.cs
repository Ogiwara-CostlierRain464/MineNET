﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Blocks
{
    public class BlockStairsAcacia : BlockStairsBase
    {
        public BlockStairsAcacia() : base(BlockFactory.ACACIA_STAIRS)
        {

        }

        public override string Name
        {
            get
            {
                return "AcaciaStairs";
            }
        }
    }
}
