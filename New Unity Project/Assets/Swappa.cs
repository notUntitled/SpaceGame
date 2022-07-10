using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swappa : MonoBehaviour
{
    public int screen;
    public void swapScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(screen);
    }
}
