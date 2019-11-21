using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Chain
    {
        public ICollection<Block> Blocks { get; private set; }
        public Block Last { get; private set; }
        public Chain()
        {
            Blocks = new List<Block>();
            var genesisBlock = new Block();

            Blocks.Add(genesisBlock);
            Last = genesisBlock;
        }

        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;
        }
    }
}
