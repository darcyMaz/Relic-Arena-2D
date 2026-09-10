using UnityEngine;

[CreateAssetMenu(fileName = "EffectRelic", menuName = "Scriptable Objects/EffectRelic")]
public class EffectRelic : Relic
{
    [SerializeField] private Effect PassiveEffect;
    [SerializeField] private Effect ActiveEffect;

    public Effect GetPassiveEffect()
    {
        return PassiveEffect;
    }
    public Effect GetActiveEffect()
    {
        return ActiveEffect;
    }
}
