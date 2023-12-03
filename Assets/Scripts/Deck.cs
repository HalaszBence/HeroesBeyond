using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    [SerializeField] private List<float> cards = new List<float>();
    [SerializeField] private string deckName;

    public Deck(List<float> _cards, string _deckName) {
        cards = _cards;
        deckName = _deckName;
    }

    public List<float> Cards { get => cards; set => cards = value; }
    public string DeckName { get => deckName; set => deckName = value; }
}
