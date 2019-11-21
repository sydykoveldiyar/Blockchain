using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class Chain
    {
        public List<Block> Blocks { get; private set; }
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


        public bool IsSafe()
        {
            var genesisBlock = new Block();
            var previousHash = genesisBlock.Hash;

            foreach (var block in Blocks.Skip(1))
            {
                var hash = block.PreviousHash;

                if (previousHash == hash)
                {
                    return true;
                }

                previousHash = block.Hash;
            }
            return false;
        }
    }
}
