using System;

public interface IEffectable
{
    // IEffectables (1) inform others that they have received or lost effects
    //              (2) have some functionality for receiving and losing effects and
    //              (3) implement each possible effect

    public event Action <Effect> OnEffectReceived;
    public event Action <Effect> OnEffectLost;


    protected void ReceiveEffect();
    protected void LoseEffect();

    protected void InstantLightning();
    protected void DelayedLightning(float delay);
    protected void SlowDownSpeed();
    protected void TwoSecondKnockout();
}
