using UnityEngine;

[CreateAssetMenu(fileName = "EffectRelic", menuName = "Scriptable Objects/EffectRelic")]
public class EffectRelic : Relic
{
    [SerializeField] private Effect RelicEffect;

    public Effect GetEffect()
    {
        return RelicEffect;
    }  
}
