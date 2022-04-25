using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public void OnButtonPress(){
        SceneManager.LoadScene("_Scene01");
    }
}
