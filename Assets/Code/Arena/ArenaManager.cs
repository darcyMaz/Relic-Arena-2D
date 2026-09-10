using UnityEngine;
using System.Collections.Generic;

public class ArenaManager : MonoBehaviour
{

    // the arena manager's first purpose is to spawn in relics at random and communicate their position for anyone to hear
    // So the arena needs a coordinate system and access to the relics themselves
    // I'll need to load in the relics from here or have a seperate class which does that and ArenaManager quickly grabs them.

    private SpriteRenderer _spriteRenderer;
    private bool _hasSR = false;

    private EffectRelic[] _effectRelics;
    private Relic[] _relics;

    [SerializeField] private int MaxRelicsBuried = 10;
    List<Relic> _buriedRelics = new List<Relic>();

    private void Awake()
    {
        // TO DO: Make this a singleton.


        // Load in all of the Relic scriptable objects.
        // Load in all of the EffectRelic scriptable objects.

        _effectRelics = Resources.LoadAll<EffectRelic>("EffectRelics");
        _relics = Resources.LoadAll<Relic>("Relics");

        // TO DO: Switching from the resources folder to addressables.

        // Get values representing the bounds of the coordinate system for spawning relics.
        if (TryGetComponent(out _spriteRenderer))
        {
            _hasSR = true;
        }
        else
        {
            Debug.Log("The ArenaManager could not find its Sprite Renderer.");
        }
    }

    private void Start()
    {
        
    }

    private Vector2 GetRandomPosition()
    {
        // This function creates a random coordinate inside of the 2D arena.
        // It finds a random x and y position by taking the x and y positions and adding/subtracting half of the scale to get a range.
        float randX = UnityEngine.Random.Range(transform.position.x - (transform.localScale.x / 2), transform.position.x + (transform.localScale.x / 2));
        float randY = UnityEngine.Random.Range(transform.position.y - (transform.localScale.y / 2), transform.position.y + (transform.localScale.y / 2));

        return new Vector2(randX, randY);
    }
}
