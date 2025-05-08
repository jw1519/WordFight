using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPacks : BaseItem
{
    public PackType packType;
    public enum PackType
    {
        vowels,
        consonants
    }
}
