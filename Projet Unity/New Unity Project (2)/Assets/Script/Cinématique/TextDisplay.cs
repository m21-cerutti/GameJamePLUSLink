using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDisplay : SingletonBehaviour<TextDisplay>
{
	public Text dialogueText;

	void Start ()
	{
		dialogueText.text = "";
	}

	public void startDialogue(Dialogue dialogue)
	{
		dialogueText.text = "";
		StartCoroutine(DisplaySentences(dialogue));
	}

	IEnumerator DisplaySentences(Dialogue dialogue)
	{
		foreach(string sentence in dialogue.sentences)
		{
			foreach (char c in sentence)
			{
				dialogueText.text += c;
				yield return new WaitForSeconds(0.03f);
			}
			yield return new WaitForSeconds(1f);
			dialogueText.text += '\n';
		}
	}


	void EndDialogue()
	{
		dialogueText.text = "";
		return;
	}
}
