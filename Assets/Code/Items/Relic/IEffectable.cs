using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEffectable: MonoBehaviour
{
    // IEffectables (1) inform others that they have received or lost effects
    //              (2) have some functionality for receiving and losing effects and
    //              (3) implement each possible effect

    public event Action <Effect> OnEffectReceived;
    public event Action <Effect> OnEffectLost;

    protected Dictionary<Effect, Action> _effectsDict = new Dictionary<Effect, Action>();

    private void Awake()
    {
        _effectsDict.TryAdd(Effect.Test, this.EffectTest);
    }   

    protected void InstantLightning()
    {

    }
    protected void EffectTest()
    {
        EffectsManager.Instance.EffectTest();
    }
}
