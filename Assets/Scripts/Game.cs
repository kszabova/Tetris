using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;

	// Use this for initialization
	void Start () {
        InstantiateTetromino();
	}
	
	// Update is called once per frame
	void Update () {
		
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

    // instantiates a new Tetromino
    public void InstantiateTetromino()
    {
        GameObject newTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetromino(), typeof(GameObject)),
                                                            new Vector2(5, 18), Quaternion.identity);
    }

    // returns random tetromino name
    string GetRandomTetromino()
    {
        int randomNumber = Random.Range(1, 8);
        string randomTetromino;
        switch (randomNumber)
        {
            case 1:
                randomTetromino = "Prefabs/TetrominoJ";
                break;
            case 2:
                randomTetromino = "Prefabs/TetrominoL";
                break;
            case 3:
                randomTetromino = "Prefabs/TetrominoLong";
                break;
            case 4:
                randomTetromino = "Prefabs/TetrominoS";
                break;
            case 5:
                randomTetromino = "Prefabs/TetrominoSquare";
                break;
            case 6:
                randomTetromino = "Prefabs/TetrominoT";
                break;
            case 7:
                randomTetromino = "Prefabs/TetrominoZ";
                break;
            default:
                randomTetromino = "";
                break;
        }
        return randomTetromino;
    }
}
