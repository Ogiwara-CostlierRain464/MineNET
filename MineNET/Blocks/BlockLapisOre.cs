﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineNET.Blocks
{
    public class BlockLapisOre : BlockSolid
    {
        public BlockLapisOre() : base(BlockFactory.LAPIS_ORE)
        {

        }

        public override string Name
        {
            get
            {
                return "LapisOre";
            }
        }
    }
}
