using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Cyral.Extensions.Xna
{
    public static class IOExtensions
    {
        /// <summary>
        /// Writes an XNA color value to a binary writer.
        /// </summary>
        public static void Write(this BinaryWriter writer, Color color)
        {
            writer.Write(color.R);
            writer.Write(color.G);
            writer.Write(color.B);
            writer.Write(color.A);
        }

        /// <summary>
        /// Reads an XNA color value from a binary reader.
        /// </summary>
        public static Color ReadColor(this BinaryReader reader)
        {
            Color color = Color.White;
            color.R = reader.ReadByte();
            color.G = reader.ReadByte();
            color.B = reader.ReadByte();
            color.A = reader.ReadByte();
            return color;
        }
    }
}
