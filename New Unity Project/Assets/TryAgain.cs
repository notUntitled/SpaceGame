using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgain : MonoBehaviour
{
    // Start is called before the first frame update
    public void tryGameAgain() {

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);  
    }

}
