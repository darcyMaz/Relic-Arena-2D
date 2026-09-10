using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class ArenaManager : MonoBehaviour
{
    private AsyncOperationHandle<Relic> _handleRelics;
    private AsyncOperationHandle<EffectRelic> _handleEffectRelics;


    // the arena manager's first purpose is to spawn in relics at random and communicate their position for anyone to hear
    // So the arena needs a coordinate system and access to the relics themselves
    // I'll need to load in the relics from here or have a seperate class which does that and ArenaManager quickly grabs them.

    private void Awake()
    {
        // Load in all of the Relic scriptable objects.
        // Load in all of the EffectRelic scriptable objects.


    }

    private void OnDestroy()
    {
        if (_handleRelics.IsValid())
        {
            Addressables.Release(_handleRelics);
        }
        if (_handleEffectRelics.IsValid())
        {
            Addressables.Release(_handleEffectRelics);
        }
    }
}
