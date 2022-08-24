 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset boardDataFile;
    
    public Vector2Int boardDimension = new Vector2Int(0 , 0);
    public List<List<GameObject>> hexBoard = null;

    // Start is called before the first frame update
    void Start()
    {
        // See HexBoardData class in BoardParser script
        BoardParser.HexBoardData boardData = BoardParser.parseBoard(boardDataFile);

        generateHexBoard(boardData.max_row, boardData.max_col, boardData.coords);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateHexBoard(int row, int col, List<List<int>> table)
    {
        // gen board
    }


}
