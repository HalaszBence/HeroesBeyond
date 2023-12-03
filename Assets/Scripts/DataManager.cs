using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

public class DataManager : MonoBehaviour
{
    string cardPath;
    [SerializeField] Player player =  new Player();

    // Start is called before the first frame update
    void Start()
    {   
        DontDestroyOnLoad(this.gameObject);

        cardPath = Application.dataPath;
        cardPath = cardPath.Replace("Assets", "player.json");

        // CardFactory cardFactory = new CardFactory();
        // int res1 = cardFactory.CreateCard(1, 5);
        // int res2 = cardFactory.CreateCard();
        // Debug.Log("Res1: " + res1 + "Res2: " + res2);

        player.Id = 1123;
        player.Cards = new List<string>
        {
            "1$2$3",
            "3$2$51",
            "1",
            "2"           
        };
        player.UserName = "SteveP1";
        player.HeroDust = 15;
        List<Deck> defaultDeck = new()
        {
            new Deck(new List<float> { 1, 2, 3, 4, 5 }, "Test1"),
            new Deck(new List<float> { 1, 2 }, "Test2"),
            new Deck(new List<float> { 4, 5 }, "Test3")
        };
        player.Decks = defaultDeck;
        var savedJson = SavePlayerData(player, cardPath);
        Debug.Log("savedJson: " + savedJson);

        player = LoadPlayerData(cardPath);
        for(int i = 0; i < player.Cards.Count; i++) {
            player.ParseCards(player.Cards[i]);
        }
    }

    string SavePlayerData(Player obj, string path) {
        string jsonString = JsonConvert.SerializeObject(obj);
        using StreamWriter writer = new(path);
        writer.Write(jsonString);
        return jsonString;
    }

    Player LoadPlayerData(string path) {
        using StreamReader reader = new(path);
        var json = reader.ReadToEnd();
        var baseCard = JsonConvert.DeserializeObject<Player>(json);
        return baseCard;
    }
}
