using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    // ----- Begin static variables ----- //
    
    public static readonly Dictionary<string, int> DirnMap = new Dictionary<string, int>()
    {
        { "NE", 0 },
        { "E", 1 },
        { "SE", 2 },
        { "SW", 3 },
        { "W", 4 },
        { "NW", 5 },
    };

    public static readonly List<Vector2Int> DirVec = new List<Vector2Int>()
    {
        new Vector2Int(-1,  1),
        new Vector2Int( 0,  2),
        new Vector2Int( 1,  1),
        new Vector2Int( 1, -1),
        new Vector2Int(-2,  0),
        new Vector2Int(-1, -1),
    };

    enum ColorState
    {
        Idle,
        Hover,
    }

    // ----- End static variables ----- //

    public static Vector2Int size = new Vector2Int(10, 10);
    public Vector2Int hexCoord;
    public List<HexCell> neighbors = new List<HexCell>(6);
    public GameObject shroom;  // Will be changed to shroom class type later
    public int playerId; // owner of this cell;

    private ColorState colorState = ColorState.Idle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
