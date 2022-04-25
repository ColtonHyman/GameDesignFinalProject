using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	public void ChangeS(string NameOfScreen)
	{
		SceneManager.LoadScene(NameOfScreen);
	}
}