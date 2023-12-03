using UnityEngine;

[CreateAssetMenu(fileName = "HeroCard", menuName = "ScriptableObjects/HeroCard")]
public class HeroCardData : BaseCardData
{
    [SerializeField] private float attackDamage;
    [SerializeField] private float magicDamage;
    [SerializeField] private float armor;
    [SerializeField] private float magicResistance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int mana;
    [SerializeField] private int actionPoints;

    public global::System.Single MagicDamage { get => magicDamage; set => magicDamage = value; }
    public global::System.Single Armor { get => armor; set => armor = value; }
    public global::System.Single MagicResistance { get => magicResistance; set => magicResistance = value; }
    public global::System.Single MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public global::System.Int32 Mana { get => mana; set => mana = value; }
    public global::System.Int32 ActionPoints { get => actionPoints; set => actionPoints = value; }
    public global::System.Single AttackDamage { get => attackDamage; set => attackDamage = value; }
}