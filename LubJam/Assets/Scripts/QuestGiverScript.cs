using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiverScript : MonoBehaviour
{
	public static bool GameIsPause = false;

	public Quest quest;

	public GameObject questWindow;

	public Text itemToFound;
	public Text duration;
	

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.X)) 
		{
			if (GameIsPause)
			{
				CloseQuestWindow();
			}
			else
			{
				OpenQuestWindow();
			}
			
		}
		
	}

	public void OpenQuestWindow()
	{
		//ZMIEN TO NA RAY CASTAAAAAAAAAAAA
		
		itemToFound.text = quest.itemToFound;
		duration.text = quest.duration.ToString();

		//stopuje czas gry
		questWindow.SetActive(true);
		Time.timeScale = 0f;
		GameIsPause = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}
	public void CloseQuestWindow()
	{
		//ZMIEN TO NA RAY CASTAAAAAAAAAAAA
		questWindow.SetActive(false);
		Time.timeScale = 1f;
		GameIsPause = false;
	}


}
