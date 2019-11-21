using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Data
{
    public class Block
    {
        public int Id { get; private set; }
        public string Data { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Hash { get; private set; }
        public string PreviousHash { get; private set; }
        public string User { get; private set; }

        public Block()
        {
            Id = 1;
            Data = "Hello, World!";
            CreatedDate = DateTime.UtcNow;
            PreviousHash = "123123123";
            User = "eldiyar";

            var data = GetData();
            Hash = GetHash(data);
        }
        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("Data can't be null or empty", nameof(data));
            }
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException("User can't be null or empty", nameof(user));
            }
            if (block == null)
            {
                throw new ArgumentNullException("Block can't be null", nameof(block));
            }
            Data = data;
            User = user;
            PreviousHash = block.Hash;
            CreatedDate = DateTime.UtcNow;
            Id = block.Id + 1;

            var blockData = GetData();
            Hash = GetHash(blockData);
        }

        private string GetData()
        {
            StringBuilder result = new StringBuilder();

            result.Append(Id.ToString());
            result.Append(Data);
            result.Append(CreatedDate.ToString("dd.MM.yyyy HH:mm:ss.fff"));
            result.Append(User);
            result.Append(PreviousHash);

            return result.ToString();
        }

        private string GetHash(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }
            hashString.Dispose();
            return hex;
        }
        public override string ToString()
        {
            string result = "Previous Hash: " + PreviousHash + "\n" + "Hash: " + Hash;
            return result;
        }
    }
}
