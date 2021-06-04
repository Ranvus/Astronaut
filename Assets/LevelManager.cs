using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Character"))
        {
            SceneManager.LoadScene("Levels");
        }
    }
}
