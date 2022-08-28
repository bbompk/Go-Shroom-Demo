 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset boardDataFile;
    [SerializeField]
    private HexCell cellPrefab;
    
    public Vector2Int boardDimension = new Vector2Int(0 , 0);
    public List<List<GameObject>> hexBoard = null;
    public static readonly Dictionary<int,Vector2Int> DirVec = new Dictionary<int, Vector2Int>()
    {
        {0, new Vector2Int(-1,  1) },
        {1, new Vector2Int( 0,  2) },
        {2, new Vector2Int( 1,  1) },
        {3, new Vector2Int( 1, -1) },
        {4, new Vector2Int(-2,  0) },
        {5, new Vector2Int(-1, -1) },
    };

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

    public List<List<HexCell>> generateHexBoard(int row, int col, List<List<int>> table)
    {
        // gen board
        List<List<HexCell>> board= new List<List<HexCell>>();
        for(int i = 0; i < table.Count; i++)
        {
            board.Add(new List<HexCell>());
            for(int j = 0; j < col; j++)
            {
                board[i].Add(null);
            }
        }
        int checkbit = -1;
        for (int i = 0; i < table.Count; i++)
        {
            if(table.Count > col)
            {
                throw new Exception();
            }
            for(int j = 0; j < table[i].Count; j++)
            {
                checkbit = table[i][j]+i;
                break;
            }
            if (checkbit != -1) break;
        }
        if (checkbit == -1) return board;
        float y = checkbit % 2, x = 0,h = HexCell.size[0], w = HexCell.size[1];
        checkbit++;
        int last = -1;
        for(int i = 0; i < table.Count; i++)
        {
            checkbit = (checkbit + 1) % 2;
            for (int j = 0; j < table[i].Count; j++)
            {
                if (table[i][j] < last || table[i][j]%2!=checkbit)
                {
                    throw new Exception();
                }
                board[i][j] = Instantiate(cellPrefab);
                //board[i][j].hexCoord = new Vector2((i-x)*h, (j-y)*w/2);
                board[i][j].transform.position = new Vector3((i - x) * h, 0, (j - y) * w / 2);
                for (int k = 0; k < 6; k++)
                {
                    if (i + DirVec[k][0] < 0 || j + DirVec[k][1] < 0 || i + DirVec[k][0] > table.Count || j + DirVec[k][1] > col) continue;
                    if (board[i + DirVec[k][0]][i + DirVec[k][1]])
                    {
                        board[i][j].neighbors[k] = board[i + DirVec[k][0]][i + DirVec[k][1]];
                        board[i + DirVec[k][0]][i + DirVec[k][1]].neighbors[(k+3)%6] = board[i][j];
                    }
                }
            }
        }
        return board;
    }


}
