using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public static CardFactory instance;
    public GameObject cardPrefab;
    public Transform cardParent;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CreateCard(Card card)
    {
        GameObject instance = Instantiate(cardPrefab);
        instance.GetComponent<SetCard>().card = card;
    }
}
