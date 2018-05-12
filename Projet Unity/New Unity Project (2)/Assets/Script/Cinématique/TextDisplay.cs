using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
	public Text dialogueText;

	private Queue<string> sentences;

	void Start ()
	{
		sentences = new Queue<string>();
	}

	public void startDialogue(Dialogue dialogue)
	{
		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator<string> TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach(char c in sentence.ToCharArray())
		{
			dialogueText.text += c;
			yield return null;
		}
	}

	void EndDialogue()
	{

	}
}
