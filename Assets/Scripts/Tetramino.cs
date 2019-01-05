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
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
        {
            transform.Rotate(0, 0, -90);
            fall = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
