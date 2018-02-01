/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
	public GameObject PlayGame;
	public Text nameText;
	public Text dialogueText;

	public Animator MrWales;
	public Animator DialogueBox;


	private Queue<string> sentences;

	private void Start()
	{
		PlayGame.SetActive(false);
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		MrWales.SetBool("isOpen", true);
		DialogueBox.SetBool("isOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();

		dialogueText.text = sentence;
	}

	public void EndDialogue()
	{
		//MrWales.SetBool("isOpen", false);
		//DialogueBox.SetBool("isOpen", false);

		PlayGame.SetActive(true);

		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Play()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
