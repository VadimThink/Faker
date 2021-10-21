using System;
using Generator;
using System.IO;

namespace SongsGenerator
{
    public class SongsGenerator : IBaseGenerator
    {
        private const string PATH_TO_TEXT = "songs.txt";
        private string[] lines;
        private Random random;
        public Type GeneratingType
        {
            get { return typeof(string); }
        }
        public SongsGenerator()
        {
            string tempText = File.ReadAllText(PATH_TO_TEXT);
            lines = tempText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            random = new Random();
        }


        public object Generate()
        {
            return lines[random.Next(lines.Length)];
        }
    }
}
