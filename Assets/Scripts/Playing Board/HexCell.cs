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

    public enum ColorState
    {
        Idle,
        Hover,
        Selected,
    }

    // ----- End static variables ----- //

    public static Vector2 size = new Vector2(2.0f, 2.5f);
    public Vector2Int hexCoord;
    public List<HexCell> neighbors = new List<HexCell>()
    {
        null,null,null,null,null,null
    };
    public GameObject shroom;  // Will be changed to shroom class type later
    public int playerId; // owner of this cell;
    public ColorState colorState = ColorState.Idle;

    private Material cellMatRef;

    // Start is called before the first frame update
    void Start()
    {
        colorState = ColorState.Idle;
        cellMatRef = gameObject.GetComponentInChildren<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        switch(colorState)
        {
            case ColorState.Idle :
                {
                    cellMatRef.SetInteger("_UseTint", 0);
                    break;
                }
            case ColorState.Selected:
                {
                    cellMatRef.SetColor("_TintColor", Color.yellow);
                    cellMatRef.SetInteger("_UseTint", 1);
                    break;
                }
        }

        
    }

    private void OnMouseDown()
    {
        colorState = ColorState.Selected;
    }
}
