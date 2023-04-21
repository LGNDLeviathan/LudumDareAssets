using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{

    private List<Card> cards;

}

public interface Card
{
    string Name { get; }
    string Description { get; }
    Sprite image { get; }

    public void SetName(string name);

    public void SetDescription(string description);

    public void SetImage(Sprite image);

}
