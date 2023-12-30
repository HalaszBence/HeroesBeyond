using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Player {
    [SerializeField] private List<string> cards;
    [SerializeField] private string userName;
    [SerializeField] private int heroDust;
    [SerializeField] private int id;
    [SerializeField] private List<Deck> decks = new();

    public List<string> Cards { get => cards; set => cards = value; }
    public string UserName { get => userName; set => userName = value; }
    public int HeroDust { get => heroDust; set => heroDust = value; }
    public int Id { get => id; set => id = value; }
    public List<Deck> Decks { get => decks; set => decks = value; }

    public Dictionary<int, string> ParseCards(string cardData) {
        string[] data = cardData.Split('$');
        switch(data.Count()) 
        {
            case 1:
                Debug.Log("Spell or Item");
                break;
            case 3:
                Debug.Log("Hero");
                break;
            default:
                Debug.Log("Unexpected length");
                break;
        }  

        return new Dictionary<int, string>();
    }
}
