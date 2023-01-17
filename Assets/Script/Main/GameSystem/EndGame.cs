using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //　スタートボタンを押したら実行する
	public void EndGames() 
    {
		SceneManager.LoadScene ("StartScene");
    }
}
