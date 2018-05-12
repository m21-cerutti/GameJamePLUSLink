using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDisplay : MonoBehaviour
{
	public Text dialogueText;

	void Start ()
	{
		dialogueText.text = "";
	}

	public void startDialogue(Dialogue dialogue)
	{
		StartCoroutine(DisplaySentences(dialogue));
	}

	IEnumerator DisplaySentences(Dialogue dialogue)
	{
		foreach(string sentence in dialogue.sentences)
		{
			StartCoroutine(TypeSentence(sentence));
			yield return new WaitForSeconds(1f);
			dialogueText.text += '\n';
		}
	}

	IEnumerator TypeSentence(string sentence)
	{
		foreach(char c in sentence)
		{
			dialogueText.text += c;
			yield return null;
			yield return null;
		}
	}

	void EndDialogue()
	{
		return;
	}
}
