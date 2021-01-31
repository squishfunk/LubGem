using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandlingQuests : MonoBehaviour
{
	public Quest quest;

	public GameObject GUI;
	public GameObject timer;
	public GameObject itemToFind;

	private TextMeshProUGUI timerMesh;
	private TextMeshProUGUI itemToFindMesh;

	private bool startTimer = false;
	float currentTime;
	private void Start()
	{
		timerMesh = timer.GetComponent<TextMeshProUGUI>();
		itemToFindMesh = itemToFind.GetComponent<TextMeshProUGUI>();
	}


	private void Update()
	{
		if (quest.isActive)
		{
			StartQuest();

			TimerStart();

		}
	}

	void StartQuest()
	{
		itemToFindMesh.text = quest.itemToFound.ToString();
		GUI.SetActive(true);
		if (startTimer == false)
		{
			currentTime = quest.duration;
			Debug.Log("starttt timer");
			startTimer = true;
		}
	}

	void TimerStart()
	{
		if (currentTime > 0)
		{
			Debug.Log(currentTime);
			currentTime -= Time.deltaTime;
			Debug.Log("timer leci");
			timerMesh.text = currentTime.ToString("0");
		}
		else
		{

		}
	}

}
