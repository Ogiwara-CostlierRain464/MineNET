﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Blocks
{
    public class BlockLadder : Block
    {
        public BlockLadder() : base(BlockFactory.LADDER)
        {

        }

        public override string Name
        {
            get
            {
                return "Ladder";
            }
        }
    }
}
