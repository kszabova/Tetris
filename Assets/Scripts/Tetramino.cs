using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino : MonoBehaviour {

    float fall = 0;
    public float fallSpeed = 1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckUserInput();
	}

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            // update grid if tetramino is at a valid position;
            // otherwise move it back at previous position
            if (IsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            // if tetramino gets outside of grid, move it back to previous position
            if (IsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
            // if tetramino gets outside of grid, rotate it back
            if (IsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            // if tetramino gets outside of grid, move it back to previous position
            if (IsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<Game>().DeleteRow();
                enabled = false;
                FindObjectOfType<Game>().InstantiateTetramino();
            }
            fall = Time.time;
        }
    }

    // returns true if tetramino is inside of grid
    bool IsValidPosition()
    {
        // check position of each square of tetramino
        foreach (Transform mino in transform)
        {
            Vector2 position = FindObjectOfType<Game>().Round(mino.position);
            if (!FindObjectOfType<Game>().IsInsideGrid(position))
            {
                return false;
            }
            // if position in grid is occupied by a tetramino other than the current one, position is invalid
            if (FindObjectOfType<Game>().GetTransformAtPosition(position) != null &&
                    FindObjectOfType<Game>().GetTransformAtPosition(position).parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}
