 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class BoardManager : MonoBehaviour
{

    public TextAsset boardDataFile;

    // Start is called before the first frame update
    void Start()
    {
        // See HexBoardData class in BoardParser script
        BoardParser.HexBoardData boardData = BoardParser.parseBoard(boardDataFile);

        foreach (List<int> line in boardData.coords)
        {
            Debug.Log(string.Join(" ", line.ToArray()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


}
