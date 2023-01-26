using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Codec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            return serializeRec(root);
        }

        string serializeRec(TreeNode node)
        {
            if (node == null)
            {
                return string.Empty;
            }
            string str = node.val.ToString();
            str += "," + serializeRec(node.left);
            str += "," + serializeRec(node.right);

            return str;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var items = data.Split(',');
            int index = 0;
            var node = deserializeRec(items, ref index );
            return node;
        }

        TreeNode deserializeRec(string[] items, ref int index)
        {
            if (index >= items.Length || items[index] == string.Empty)
            {
                index++;
                return null;
            }
            int val = int.Parse(items[index]);
            TreeNode node = new TreeNode(val);
            index++;
            node.left = deserializeRec(items, ref index);
            node.right = deserializeRec(items, ref index);
            return node;
        }
    }
}
