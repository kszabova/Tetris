using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

	public void PlayAgain()
    {
        SceneManager.LoadScene("Level");
    }
}
