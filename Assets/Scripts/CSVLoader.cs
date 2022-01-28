using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text.RegularExpressions;

public class CSVLoader
{
    private TextAsset _csvFile;
    private char _lineSeparator = '\n';
    private char _surround = '"';
    private string[] _fieldSeparator = { "\",\"" };

    public void LoadCSV()
    {
        _csvFile = Resources.Load<TextAsset>("localisation");
    }

    public Dictionary<string, string> GetDictionaryValues(string attributeId)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = _csvFile.text.Split(_lineSeparator);
        
        int attributeIndex = -1;

        string[] headers = lines[0].Split(_fieldSeparator, StringSplitOptions.None);
        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i].Contains(attributeId))
            {
                attributeIndex = i;
                break;
            }
        }

        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        for (int i = 1; i <lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = CSVParser.Split(line);

            for (int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', _surround);
                fields[f] = fields[f].TrimEnd(' ', _surround);
            }

            if (fields.Length > attributeIndex)
            {
                var key = fields[0];
                if (dictionary.ContainsKey(key))
                    continue;

                var value = fields[attributeIndex];
                dictionary.Add(key, value);
            }
        }
        return dictionary;
    }

}
