using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    string cardPath;
    BaseCardData baseCardData =  new BaseCardData();

    // Start is called before the first frame update
    void Start()
    {   
        cardPath = Application.dataPath;
        cardPath = cardPath.Replace("Assets", "cards.json");

        // CardFactory cardFactory = new CardFactory();
        // int res1 = cardFactory.CreateCard(1, 5);
        // int res2 = cardFactory.CreateCard();
        // Debug.Log("Res1: " + res1 + "Res2: " + res2);

        // baseCardData.id = 1123;
        // baseCardData.cardName = "Harold";
        // baseCardData.desc = "A very powerful card";
        // var savedJson = SaveJsonData(baseCardData, cardPath);
        // Debug.Log("savedJson: " + savedJson);

        // baseCardData = LoadJsonData(new Object(), cardPath);
        // Debug.Log("Loaded cards data: " + baseCardData.id);
    }

    string SaveJsonData(BaseCardData obj, string path) {
        string jsonString = JsonConvert.SerializeObject(obj);
        using StreamWriter writer = new(path);
        writer.Write(jsonString);
        return jsonString;
    }

    BaseCardData LoadJsonData(UnityEngine.Object obj, string path) {
        using StreamReader reader = new(path);
        var json = reader.ReadToEnd();
        var baseCard = JsonConvert.DeserializeObject<BaseCardData>(json);
        return baseCard;
    }
}
