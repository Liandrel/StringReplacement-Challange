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

        public delegate string ParameterReplacement(string parameter);
        private Dictionary<string, string> InTextParameters { get; set; } = new();
        public void ReplaceText(string oldText, string newText, string textPath)
        {
            List<List<string>> fullText = ReadTextFromFile(textPath);

            foreach (var line in fullText)
            {

                for (int i = 0; i < line.Count; i++)
                {
                    if (line[i].Contains(oldText))
                    {
                        line[i] = line[i].Replace(oldText, newText);
                    }
                }

            }
            SaveTextToFile(fullText, textPath);
        }

        public void ReplaceParametersWithText(string textPath, ParameterReplacement AskUserForText)
        {
            List<List<string>> fullText = ReadTextFromFile(textPath);

            foreach (var line in fullText)
            {

                for (int i = 0; i < line.Count; i++)
                {
                    if (line[i].Contains('{') && line[i].Contains('}'))
                    {
                        string oldText = line[i].Between("{", "}");

                        if(InTextParameters.ContainsKey(oldText) == false)
                        {
                            string newText = AskUserForText(oldText);
                            InTextParameters.Add(oldText, newText);
                        }

                        line[i] = line[i].Replace('{' + oldText + '}', InTextParameters[oldText]);
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
