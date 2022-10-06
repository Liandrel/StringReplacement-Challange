using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReplaceChall
{
    internal class StringReplaceProcessor
    {
        private string fullText;

        public void ReplaceText(string oldText, string newText, string textPath)
        {
            List<List<string>> fullText = ReadTextFromFile(textPath);

            foreach (var line in fullText)
            {

                for (int i = 0; i < line.Count; i++)
                {
                    if (line[i].Contains(oldText))
                    {
                        int index = line.FindIndex(x => x == line[i]);
                        if (index != -1)
                        {
                            line[index] = line[index].Replace(oldText, newText);
                        }
                    }
                }

            }
            SaveTextToFile(fullText, textPath);
        }
        
        private void SaveTextToFile(List<List<string>> textToSave, string textPath)
        {
            List<string> lines = new();

            foreach (var line in textToSave)
            {
                lines.Add(String.Join(" ", line));
            }

            File.WriteAllLines(textPath, lines);
        }

        private List<List<string>> ReadTextFromFile(string textPath)
        {
            List<List<string>> output = new();

            List<string> text = File.ReadAllLines(textPath).ToList();

            text.ForEach(line =>
            {
                output.Add(line.Split(' ').ToList());
            });

            return output;
        }
    }
}
