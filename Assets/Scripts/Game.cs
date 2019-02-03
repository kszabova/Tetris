using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

	// Use this for initialization
	void Start () {
        InstantiateTetramino();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // updates grid; null indicates position is empty,
    // if position is occupied, grid[x,y] contains the Transform of the object occupying it
    public void UpdateGrid(Tetramino tetramino)
    {
        for (int y = 0; y < gridHeight; ++y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == tetramino.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform mino in tetramino.transform)
        {
            Vector2 pos = Round(mino.position);
            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    // returns Transform object at current grid position
    public Transform GetTransformAtPosition(Vector2 pos)
    {
        if (pos.y > gridHeight - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    // returns true if object is inside of grid
    public bool IsInsideGrid(Vector2 position)
    {
        return ((int)position.x >= 0 && (int)position.x < gridWidth && (int)position.y >= 0);
    }

    // rounds decimal position to integers
    public Vector2 Round(Vector2 position)
    {
        return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
    }

    // instantiates a new Tetramino
    public void InstantiateTetramino()
    {
        GameObject newTetramino = (GameObject)Instantiate(Resources.Load(GetRandomTetramino(), typeof(GameObject)),
                                                            new Vector2(5, 18), Quaternion.identity);
    }

    // returns random tetramino name
    string GetRandomTetramino()
    {
        int randomNumber = Random.Range(1, 8);
        string randomTetramino;
        switch (randomNumber)
        {
            case 1:
                randomTetramino = "Prefabs/TetraminoJ";
                break;
            case 2:
                randomTetramino = "Prefabs/TetraminoL";
                break;
            case 3:
                randomTetramino = "Prefabs/TetraminoLong";
                break;
            case 4:
                randomTetramino = "Prefabs/TetraminoS";
                break;
            case 5:
                randomTetramino = "Prefabs/TetraminoSquare";
                break;
            case 6:
                randomTetramino = "Prefabs/TetraminoT";
                break;
            case 7:
                randomTetramino = "Prefabs/TetraminoZ";
                break;
            default:
                randomTetramino = "";
                break;
        }
        return randomTetramino;
    }
}
