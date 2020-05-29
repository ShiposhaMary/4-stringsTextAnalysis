using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var unSort = new Dictionary<string, Dictionary<string, int>>();
            var result = new Dictionary<string, string>();
            var firstWords = new StringBuilder();
            unSort = CreateDictionary(text, unSort, 1);
            var forSort = CreateDictionary(text, unSort, 2);
            return SortDictionary(forSort, result, firstWords);
        }

        public static Dictionary<string, Dictionary<string, int>> CreateDictionary( List<List<string>> text,
            Dictionary<string, Dictionary<string, int>> unSort, int a)
        {
            foreach (var sentence in text)
                for (var i = 0; i < sentence.Count - a; i++)
                {
                    var bond = ""; var val = "";
                    if (a == 2) { bond = sentence[i] + " " + sentence[i + 1]; val = sentence[i + 2]; }
                    else { bond = sentence[i]; val = sentence[i + 1]; }
                    if (unSort.ContainsKey(bond))
                        if (unSort[bond].ContainsKey(val))
                            unSort[bond][val]++;
                        else unSort[bond][val] = 1;
                    else unSort[bond] = new Dictionary<string, int> { { val, 1 } };
                }
            return unSort;
        }

        public static Dictionary<string, string> SortDictionary(Dictionary<string, Dictionary<string, int>> forSort,
            Dictionary<string, string> result,
            StringBuilder firstWords)
        {
            var maxValue = 0;
            var endWord = "";
            foreach (var pair in forSort)
            {
                firstWords.Append(pair.Key);
                foreach (var value in forSort[pair.Key])
                    if (value.Value > maxValue)
                    {
                        maxValue = value.Value;
                        endWord = value.Key;
                    }
                    else if (value.Value == maxValue)
                        if (string.CompareOrdinal(value.Key, endWord.ToString()) < 0) endWord = value.Key;
                result.Add(firstWords.ToString(), endWord.ToString());
                maxValue = 0;
                endWord = "";
                firstWords.Clear();
            }
            return result;
        }
    }
}