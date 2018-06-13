using MineNET.Blocks;

namespace MineNET.Items
{
    public class ItemBlock : Item
    {
        public ItemBlock(Block block) : base(block.ID, block.Damage)
        {
        }
    }
}
