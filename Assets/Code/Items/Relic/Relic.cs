 using UnityEngine;

[CreateAssetMenu(fileName = "Relic", menuName = "Scriptable Objects/Relic")]
public class Relic : Item
{
    [SerializeField] private float Price;

    public float GetPrice()
    {
        return Price;
    }
}
