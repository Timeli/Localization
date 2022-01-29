using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    // must be UTF-8(localization file)
    public enum Language
    { 
        English,
        Russian
    }

    public static Language language = Language.English;

    private static Dictionary<string, string> _localisedEN;
    private static Dictionary<string, string> _localisedRU;

    public static bool isInit;

    public static CSVLoader csvLoader;

    // Собирает словари переводов
    public static void Init()
    {
        csvLoader = new CSVLoader();
        // загружаем файл CSV 
        csvLoader.LoadCSV();

        // заполняем словари
        UpdateDictionaries();

        isInit = true;
    }

    private static void UpdateDictionaries()
    {
        _localisedEN = csvLoader.GetDictionaryValues("en");
        _localisedRU = csvLoader.GetDictionaryValues("ru");
    }

    //Получаем значение по ключу и выбранному языку
    public static string GetLocalisedValue(string key)
    {
        if (isInit == false)
            Init();

        string value = key;

        switch (language)
        {
            case Language.English:
                _localisedEN.TryGetValue(key, out value);
                break;
            case Language.Russian:
                _localisedRU.TryGetValue(key,out value);
                break;
        }
        return value;
    }

    public static void Add(string key, string value)
    {
        if (value.Contains("\""))
            value.Replace('"', '\"');

        if (csvLoader == null)
            csvLoader = new CSVLoader();

        csvLoader.LoadCSV();
        csvLoader.Add(key, value);
        csvLoader.LoadCSV();

        UpdateDictionaries();
    }

    public static void Replace(string key, string value)
    {
        if (value.Contains("\""))
            value.Replace('"', '\"');

        if (csvLoader == null)
            csvLoader = new CSVLoader();

        csvLoader.LoadCSV();
        csvLoader.Edit(key, value);
        csvLoader.LoadCSV();

        UpdateDictionaries();
    }

    public static void Remove(string key)
    {
        if (csvLoader == null)
            csvLoader = new CSVLoader();

        csvLoader.LoadCSV();
        csvLoader.Remove(key);
        csvLoader.LoadCSV();

        UpdateDictionaries();
    }
}
