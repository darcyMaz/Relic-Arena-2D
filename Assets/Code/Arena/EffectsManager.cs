using System.Threading.Tasks;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    private bool TestEffectLock = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public async void EffectTest()
    {
        if (TestEffectLock)
        {
            return;
        }

        TestEffectLock = true;
        UIManager.Instance.TestUIUpdate("Effect Test");
        await Task.Delay(3000);
        UIManager.Instance.TestUIUpdate("");
        TestEffectLock = false;
    }
        
}
