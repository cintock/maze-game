using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maze.Implementation;
using System;

public class CreateWall : MonoBehaviour
{
    public GameObject wallPart;
    public GameObject player;

    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        try
        {

            /*
            CreateRightWall(0, 0);
            CreateRightWall(0, 1);

            CreateBottomWall(0, 0);
            CreateBottomWall(0, 1);
            */


            int rowCount = 35;
            int colCount = 35;

            
            for (int row = 1; row < rowCount; row++)
            {
                CreateLeftWall(row, 0);
                CreateRightWall(row, colCount - 1);
            }

            for (int col = 0; col < colCount; col++)
            {
                CreateTopWall(0, col);
                CreateBottomWall(rowCount - 1, col);
            }
            


            
            IMazeGenerator generator = new EllerModMazeGenerator();

            IMazeView maze = generator.Generate(rowCount, colCount);
            rnd = new System.Random();
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    MazeSide cell = maze.GetCell(row, col);
                    if (cell.HasFlag(MazeSide.Bottom))
                    {
                        CreateBottomWall(row, col);
                    }

                    if (cell.HasFlag(MazeSide.Right))
                    {
                        CreateRightWall(row, col);
                    }
                }
            }

            player.transform.position = new Vector3((colCount - 1) * 5f, 2.5f, 2.5f);
            
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    bool RandomBool()
    {
        return rnd.Next() % 2 == 0;
    }

    void CreateLeftWall(int row, int col)
    {
        CreateRightWall(row, col - 1, string.Format("LeftWall({0}; {1})", row, col));
    }

    void CreateTopWall(int row, int col)
    {
        CreateBottomWall(row - 1, col, string.Format("TopWall({0}; {1})", row, col));
    }

    void CreateBottomWall(int row, int col, string name = null)
    {
        var g = Instantiate(wallPart, new Vector3(col * 5f, 2.5f, (row + 1) * 5f), Quaternion.identity);
        g.name = name ?? string.Format("BottomWall({0}; {1})", row, col);
    }

    void CreateRightWall(int row, int col, string name = null)
    {
        var g = Instantiate(wallPart,
            new Vector3((col) * 5f + 2.5f, 2.5f, row * 5f + 2.5f),
            Quaternion.Euler(new Vector3(0, 90, 0)));

        g.name = name ?? string.Format("RightWall({0}; {1})", row, col);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
