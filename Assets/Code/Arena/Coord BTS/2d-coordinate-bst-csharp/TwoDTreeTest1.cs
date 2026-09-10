
using UnityEngine;

public class TwoDTreeTest1: MonoBehaviour
{
    private void Start()
    {
        TwoDTree tree = new TwoDTree();

        // Debug.Log("Random Tree:");

        for (int i = 0; i < 10; i++)
        {
            Vector2 generatedVector = new Vector2(UnityEngine.Random.Range(0, 100),
                UnityEngine.Random.Range(0, 100));

            // Debug.Log( generatedVector );

            tree.Insert( generatedVector );
        }
        
        tree.Insert(new Vector2(41, 20));
        
        tree.Insert(new Vector2(99,99));
        
        tree.Insert(new Vector2(1,1));
        
        tree.Insert(new Vector2(50,50));

        Debug.Log("Search on: 41,20");
        Debug.Log(tree.Search(new Vector2(41, 20)));
        Debug.Log("Search on: 99,99");
        Debug.Log(tree.Search(new Vector2(99, 99)));
        Debug.Log("Search on: 1,1");
        Debug.Log(tree.Search(new Vector2(1, 1)));
        Debug.Log("Search on: 50,50");
        Debug.Log(tree.Search(new Vector2(50, 50)));

        Debug.Log(tree.Search(new Vector2(60, 23)));

    }
}
