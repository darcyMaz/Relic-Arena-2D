using UnityEngine;
using System.Collections.Generic;
using System;

public class ArenaManager : MonoBehaviour
{

    // the arena manager's first purpose is to spawn in relics at random and communicate their position for anyone to hear
    // So the arena needs a coordinate system and access to the relics themselves
    // I'll need to load in the relics from here or have a seperate class which does that and ArenaManager quickly grabs them.

    public event Action OnLackingBuriedRelics;

    private SpriteRenderer _spriteRenderer;
    private bool _hasSR = false;


    // private EffectRelic[] _effectRelics;
    // private Relic[] _relics;
    private List<EffectRelic> _effectRelics;
    private List<Relic> _relics;

    [SerializeField] private float EffectRelicSpawnRate = 0.1666f;
    [SerializeField] private float RelicSpawnRate = 1;

    [SerializeField] private int MaxRelicsBuried = 10;
    private TwoDTree _relicTree = new TwoDTree();


    private void Awake()
    {
        // TO DO: Make this a singleton.


        // Load in all of the Relic scriptable objects.
        // Load in all of the EffectRelic scriptable objects.

        EffectRelic[] effectRelics = Resources.LoadAll<EffectRelic>("EffectRelics");
        Relic[] relics = Resources.LoadAll<Relic>("Relics");

        foreach (Relic relic in relics)
        {

        }

        // __effectRelics = new List<EffectRelic>(_effectRelics);  // Error here!

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

    // This is async as burying a relic could take more than one frame. Maybe not.
    private async void Update()
    {
        

    }

    private void Start()
    {

        // TO-DO: Change this such that the code can use a maximum range to see if there are any relics nearby (so relics don't spawn in too close).
        // I can use or create a comparator for this. Go through all other positions, O(n).
        for (int relicIndex = 0; relicIndex < 10; relicIndex++)
        {
            int relicAttempts = 0;
            int maxRelicAttempts = 20;

            // Bury 10 relics.
            for (; relicAttempts < maxRelicAttempts; relicAttempts++)
            {
                // Check if we are randomly generating duplicates.
                // 20 attempts, and if we somehow generate 20 duplicates attempting to bury 1 relic, we'll throw an error.
                Vector2 potentialRelicPosition = GetRandomPosition();
                if (_relicTree.Search( potentialRelicPosition ))
                {
                    continue;
                }
                break;
            }
            
            if (maxRelicAttempts == 20)
            {
                Debug.LogError("The ArenaManager treid to bury a relic but it generated duplicate coordinates (tried to bury a relic on top of another) 20 times in a row. There is likely a flaw in the code logic.");
            }

        }

    }

    private Vector2 GetRandomPosition()
    {
        // This function creates a random coordinate inside of the 2D arena.
        // It finds a random x and y position by taking the x and y positions and adding/subtracting half of the scale to get a range.
        float randX = UnityEngine.Random.Range(transform.position.x - (transform.localScale.x / 2), transform.position.x + (transform.localScale.x / 2));
        float randY = UnityEngine.Random.Range(transform.position.y - (transform.localScale.y / 2), transform.position.y + (transform.localScale.y / 2));

        return new Vector2(randX, randY);
    }



    private void BuryRelic(Relic relicToBury)
    {

    }
    /*
    private Relic RandomlyChooseRelic()
    {
        // There is certainly a more concise way to do this random choice of Item type.
        float randResult = UnityEngine.Random.Range(0,1);
        if (randResult >= 0 && randResult < EffectRelicSpawnRate)
        {
            //return _effectRelics[UnityEngine.Random.Range(0,_effectRelics.Length)];
        }
        else if (randResult >= EffectRelicSpawnRate && randResult < RelicSpawnRate)
        {
            //return _relics[UnityEngine.Random.Range(0,_relics.Length)];
        }
        else if (randResult >= RelicSpawnRate || randResult <= 1)
        {
            Debug.Log("ArenaManager.BurRelic() tried to randomly choose what kind of Item to spawn, but the random number did not fit the code logic: " + randResult);
            return null;
        }
        else
        {
            Debug.Log("ArenaManager.BurRelic() tried to randomly choose what kind of Item to spawn, but the random number did not fit the code logic: " + randResult);
            return null;
        }
    }
    */
}
