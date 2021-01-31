using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestGiverScript : MonoBehaviour
{
	public FirstPersonLook cameraMove;
	public static bool GameIsPause = false;
	public HandlingQuests player;

	private GameObject[] items;

	public Quest quest;

	public GameObject questWindow;

	public Text itemToFound;
	public Text duration;

	public void Start()
	{
		//PRZYPISUJE WSZYSTKIE PRZEDMIOTY Z FOLDERU RESOURCES/ITEMS DO ZMIENNEJ ITEMS
		//items = Resources.LoadAll<GameObject>("Items");
		items = Resources.LoadAll("Items").Cast<GameObject>().ToArray();
		Debug.Log(items);
	}

	public void Update()
	{

	}

	public void OpenQuestWindow()
	{
		CreateRandomQuest();
		cameraMove.enabled = false;
		//nadaje nazwe
		itemToFound.text = quest.itemToFound.name;
		duration.text = quest.duration.ToString();

		//stopuje czas gry
		questWindow.SetActive(true);
		//Time.timeScale = 0f;
		GameIsPause = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}
	public void CloseQuestWindow()
	{
		cameraMove.enabled = true;
		questWindow.SetActive(false);
		//Time.timeScale = 1f;
		GameIsPause = false;
		Cursor.visible = false;
	}

	public void AcceptQuest()
	{
		quest.isActive = true;
		player.quest = quest;
		CloseQuestWindow();
	}
	public void CreateRandomQuest()
	{
		//Wybiera jeden z przedmiotów z itemsów
		float index = Random.Range(0, items.Length);
		quest.itemToFound = items[(int)index];

		//Wybiera losowy czas w zakresie od 30 sek do 120
		index = Random.Range(30, 120);
		quest.duration = index;

	}

}
