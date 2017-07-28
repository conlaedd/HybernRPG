﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour {

	private JSONDialogueReader dialouge;
	public string fileName;
	public string speaker;
	public string id;
	
	void OnEnable()
	{
		dialouge = GameObject.Find("TextBoxCanvas").GetComponent<JSONDialogueReader>();
	}
	void OnTriggerEnter2D()
	{
		dialouge.BeginDialogue (fileName, speaker, id);
		
		GameObject.Destroy( this.gameObject );
	}
}