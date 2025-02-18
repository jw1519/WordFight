using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Attack Card")]
public class AttackCard : Card, ICard
{
    private void OnEnable()
    {
        cardType = CardType.Attack;
    }
    public void Play()
    {
        SetEnemy setEnemy = FindFirstObjectByType<SetEnemy>();
        if (setEnemy != null)
        {
            setEnemy.TakeDamnage(value);
        }
    }
}
