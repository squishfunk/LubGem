using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiverScript : MonoBehaviour
{
	public static bool GameIsPause = false;
	public HandlingQuests player;

	public GameObject[] items;

	public Quest quest;

	public GameObject questWindow;

	public Text itemToFound;
	public Text duration;

    [Header("MM parameters")]
    public NPCInteraction npcInteraction;
    private bool isQuestInfoActive = false;

	public void Start()
	{
		//PRZYPISUJE WSZYSTKIE PRZEDMIOTY Z FOLDERU RESOURCES/ITEMS DO ZMIENNEJ ITEMS
		items = Resources.LoadAll<GameObject>("Items");

        //MM
        npcInteraction = FindObjectOfType<NPCInteraction>();
	}

	public void Update()
	{
        //MM
        if(npcInteraction.CanRecevieQuest)
        {
            if(Input.GetMouseButtonUp(0) && !isQuestInfoActive)
            {
                questWindow.SetActive(true);
                isQuestInfoActive = true;
            }
            else if (Input.GetMouseButtonUp(0) && isQuestInfoActive)
                    {
                     questWindow.SetActive(false);
                     isQuestInfoActive = false;
            }
                    
        }
        //        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

        //RaycastHit hitInfo;
      
        //if (Physics.Raycast(ray, out hitInfo, 2f));
        //{
        //    var selection = hitInfo.transform;


		//ZMIENIC TO NA RAYCASTA!!!!!!!!!!!!!
		//if (Input.GetKeyDown(KeyCode.X)) 
		//{
		//	if (GameIsPause)
		//	{
		//		CloseQuestWindow();
		//	}
		//	else
		//	{
		//		CreateRandomQuest();
		//		OpenQuestWindow();
		//	}
			
		//}
		
	}

	public void OpenQuestWindow()
	{
		//nadaje nazwe
		itemToFound.text = quest.itemToFound.name;
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
		questWindow.SetActive(false);
		Time.timeScale = 1f;
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
