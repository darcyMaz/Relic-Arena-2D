using System;

public interface IEffectable
{
    // Think about changing this to be a list of effects.

    public event Action <Effect> OnEffectReceived;
    public event Action <Effect> OnEffectLost;


    protected void ReceiveEffect();
    protected void LoseEffect();
}
