using UnityEngine;

[CreateAssetMenu(fileName = "BaseCard", menuName = "ScriptableObjects/BaseCard")]
public class BaseCardData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string cardName;
    [SerializeField] private string desc;
    [SerializeField] private Sprite sprite; //something for the card display (type may defer)

    public int Id { get => id; set => id = value; }
    public string CardName { get => cardName; set => cardName = value; }
    public string Desc { get => desc; set => desc = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
}