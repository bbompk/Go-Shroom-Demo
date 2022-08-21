using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingCell : MonoBehaviour
{

    public static readonly Dictionary<string, int> Direction = new Dictionary<string, int>()
    {
        { "NE", 0 },
        { "E", 1 },
        { "SE", 2 },
        { "SW", 3 },
        { "W", 4 },
        { "NW", 5 },
    };

    public List<PlayingCell> neighbors = new List<PlayingCell>(6);

    private Vector2Int coord;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
