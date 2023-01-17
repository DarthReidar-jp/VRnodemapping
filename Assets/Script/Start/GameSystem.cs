using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    //　スタートボタンを押したら実行する
	public void StartGame() 
    {
		SceneManager.LoadScene ("MainScene");
    }
 
    //　ゲーム終了ボタンを押したら実行する
    public void EndGame() 
    {
	    #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	    #else
		Application.Quit();
	    #endif
}
}
