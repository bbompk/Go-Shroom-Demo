using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardParser : MonoBehaviour
{

    public class HexBoardData
    {
        public int max_row;
        public int max_col;
        public List<List<int>> coords;

        public HexBoardData(int i, int j)
        {
            max_row = i;
            max_col = j;
            coords = new List<List<int>>();
            for (int k = 0; k < i; k++)
            {
                coords.Add(new List<int>());
            }
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // dont have to care about how data is parsed, but be sure to understand the HexBoardData class
    public static HexBoardData parseBoard(TextAsset tf)
    {
        Debug.Log("Compiling Board Data ...");
        Debug.Log(tf.text);
        string fs = tf.text;
        string[] lines = fs.Split("\n");
        int row = 0, col = 0;
        bool contains_dim = false;
        int row_count = 0;
        HexBoardData result = null;
        bool init_result = false;

        foreach (string line in lines)
        {
            bool checkemptyline = true;
            if (string.IsNullOrWhiteSpace(line)) continue;
            for (int k = 0; k < line.Length; k++)
            {
                if (line[k] != ' ' || line[k] != '\n' || line[k] != '\r')
                {
                    checkemptyline = false;
                }
            }
            if (checkemptyline) continue;

            if (line.Length > 0)
            {
                if (line[0] == '#') continue;

                string[] linedata = line.Split(" ");
                if (linedata.Length > 0)
                {
                    if (linedata[0].Length >= 2)
                    {
                        string header = linedata[0];
                        if (header.Equals("dim"))
                        {
                            if (linedata.Length >= 3)
                            {
                                try
                                {
                                    row = Int32.Parse(linedata[1]);
                                    col = Int32.Parse(linedata[2]);
                                    contains_dim = true;
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("Board Data parsing error: Error parsing dimension");
                                }
                            }
                        }
                        else if (header.Length >= 2)
                        {
                            if (header[0] == 'r')
                            {
                                if (!contains_dim) throw new Exception("Board Data parsing error: missing dimensions");

                                if (!init_result)
                                {
                                    result = new HexBoardData(row, col);
                                    init_result = true;
                                }


                                int row_num = 0;
                                try
                                {
                                    row_num = Int32.Parse(header.Substring(1, header.Length - 1));
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("Board Data parsing error: Invalid Header");
                                }

                                for (int k = 1; k < linedata.Length; k++)
                                {
                                    int col_num = 0;
                                    try
                                    {
                                        col_num = Int32.Parse(linedata[k]);
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exception("Board Data parsing error: Invalid Coord");
                                    }
                                    result.coords[row_num].Add(col_num);
                                }
                                row_count++;
                            }
                            else
                            {
                                throw new Exception("Board Data parsing error: Invalid Header");
                            }

                        }
                        else
                        {
                            throw new Exception("Board Data parsing error: Invalid Header");
                        }
                    }
                    else throw new Exception("Board Data parsing error: Invalid Header");
                }
            }
        }
        if (!contains_dim) throw new Exception("Board Data parsing error: missing dimensions");
        if (row_count != row) throw new Exception("Board Data parsing error: given row data does not match row dimension");

        Debug.Log("Board Data compiled successfully.");
        return result;
    }
}
