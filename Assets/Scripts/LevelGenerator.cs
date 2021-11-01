using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hello marker!! I hope you're having a nice day!
// I didn't get to finish this section because I ran out of time but I did give it a very fair shot in an attempt
// to show you that I do understand what I conceptually need to do but I struggled technically to get it working!

public class LevelGenerator : MonoBehaviour
{
    // Assign all the game objects using prefabs that I've set up
    [SerializeField]
    private GameObject doubleCorner;

    [SerializeField]
    private GameObject doubleWall;

    [SerializeField]
    private GameObject singleCorner;

    [SerializeField]
    private GameObject singleWall;

    [SerializeField]
    private GameObject tJunction;

    [SerializeField]
    private GameObject tileMapGrid;

    [SerializeField]
    private GameObject powerPellet;

    [SerializeField]
    private GameObject coin;

    // For placing sprites where I need them 

    private float cursorX =0;
    private float cursorY =0;

    int[,] levelMap = { 
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 }, 
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4 }, 
        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3 }, 
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3 }, 
        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4 }, 
        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0 }, 
        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0 }, 
    };

    void Start()
    {
        // I set the grid map to false but I've commented this out because I didn't get this working.
        //tileMapGrid.SetActive(false);

        //Set the top left starting block
        GameObject startingBlock = Instantiate(doubleCorner, new Vector3(0, 0, 0), Quaternion.identity);
        startingBlock.transform.rotation = Quaternion.Euler(0, 0, 90);

        // go through the 2D array and then work out what each piece should be by working through multiple checks. 
        // It starts at a high level from the basics - if it is a 1, it is a double corner. If it is a 2, it is a double wall etc.
        // From there, it goes into further checks to work out the orientation of those pieces. 
        // However, my helper method below isn't working and as such, this is as far as I got before running out of time :(
        // I do believe this could've worked if I had given myself more time!

        for (int row = 0; row < levelMap.GetLength(0); row++)
        {
            for (int col = 0; col < levelMap.GetLength(1); col++)
            {
                if (levelMap[row, col] == 0)
                {
                    continue;
                }
                else if (levelMap[row, col] == 1)
                {
                    if (checkWall(col - 1, row) == "out of bounds" && checkWall(col + 1, row) == "double wall")
                    {
                        if (checkWall(col, row - 1) == "out of bounds")
                        {
                            continue;
                        }
                        else
                        {
                            GameObject temp = Instantiate(doubleWall, new Vector3(cursorX, cursorY, 0), Quaternion.identity);
                            temp.transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                    }
                    if (checkWall(col - 1, row) == "double wall" && checkWall(col + 1, row) == "out of bounds")
                    {
                        if (checkWall(col, row - 1) == "out of bounds")
                        {
                            GameObject temp = Instantiate(doubleWall, new Vector3(cursorX, cursorY, 0), Quaternion.identity);
                        }
                        else
                        {
                            GameObject temp = Instantiate(doubleWall, new Vector3(cursorX, cursorY, 0), Quaternion.identity);
                            temp.transform.rotation = Quaternion.Euler(0, 0, 270);
                        }
                    }
                }

                else if (levelMap[row, col] == 2)
                {
                    if (checkWall(col - 1, row) == "out of bounds" && checkWall(col + 1, row) == "out of bounds")
                    {
                        Instantiate(doubleWall, new Vector3(cursorX, cursorY, 0), Quaternion.identity); 
                    }

                    GameObject temp = Instantiate(doubleWall, new Vector3(cursorX, cursorY, 0), Quaternion.identity);
                    temp.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (levelMap[row, col] == 3)
                {
                    //single corner
                }
                else if (levelMap[row, col] == 4)
                {
                    //single wall
                }
                else if (levelMap[row, col] == 5)
                {
                    //coin
                }
                else if (levelMap[row, col] == 6)
                {
                    //power pellet
                }
                else if (levelMap[row, col] == 7)
                {
                    //t junction
                }

                cursorX += 0.32f;
            }
            cursorX = 0f;
            cursorY -= 0.32f;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //I use this as a check to help me identify what is to the left or the right of a given index - this allows me to work out what the orientation of a piece should technically be.
    string checkWall(int col, int row)
    {
        if (col > -1 && row > -1 && col < 14 && row < 15)
        {
            if (levelMap[row, col] == 1)
            {
                return "double corner";
            }
            else if (levelMap[row, col] == 2)
            {
                return "double wall";
            }
            else if (levelMap[row, col] == 3) 
            {
                return "single corner";
            }
            else if (levelMap[row, col] == 4)
            {
                return "single wall";
            }
            else if (levelMap[row, col] == 5)
            {
                return "coin";
            }
            else if (levelMap[row, col] == 6)
            {
                return "power pellet";
            }
            else if (levelMap[row, col] == 7)
            {
                return "t junction";
            }
        }
        else
        {
            return "out of bounds";
        }

        return "out of bounds";
    }
}
