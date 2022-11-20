using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public Sprite sprite;
    public enum ItemType
    {
        COIN,
        FOOD
    }
    public ItemType itemType;
}
