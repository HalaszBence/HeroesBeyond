using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardFactory
{
    const int defaultRange = 5;

    public int CreateCard() {
        Debug.Log("Here");
        return Random.Range(1, defaultRange);
    }

     public int CreateCard(int startingRange, int endRange) {
        Debug.Log("There");
        return Random.Range(startingRange, endRange);
    }
}