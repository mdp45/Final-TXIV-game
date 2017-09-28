using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Ctrl : MonoBehaviour {

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}