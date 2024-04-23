using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgainButton : MonoBehaviour
{
    // Start is called before the first frame update
public void GoTo(){
    SceneManager.LoadScene(0);
}
}
