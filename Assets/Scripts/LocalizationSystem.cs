using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    public enum Language
    { 
        English,
        Russian
    }

    public static Language language = Language.English;

    private static Dictionary<string, string> localisesEN;
    private static Dictionary<string, string> localisesRU;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedRU = csvLoader.GetDictionaryValues("ru");
    }

}
