using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSpellCard", menuName = "ScriptableObjects/ItemSpellCard")]
public class ItemSpellCardData : BaseCardData
{
    [SerializeField] private int ability;

    public global::System.Int32 Ability { get => ability; set => ability = value; }
}