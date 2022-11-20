using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public Sprite sprite;
    public int value;
    public enum ItemType
    {
        COIN,
        FOOD
    }
    public ItemType itemType;
}
