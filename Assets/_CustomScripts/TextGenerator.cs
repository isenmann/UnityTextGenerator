using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextGenerator : MonoBehaviour
{
    public GameObject AvailableLetters;
    public string TextToBeRendered;
    public float SpaceBetweenLetters;
    public string[] Prefix;
    public string Postfix;

    private float OldSpaceBetweenLetters;
    private string OldString;

    void Start ()
    {
        this.OldString = this.TextToBeRendered;
        this.OldSpaceBetweenLetters = this.SpaceBetweenLetters;
	}
	
	void Update ()
    {
        if (this.OldString != this.TextToBeRendered.Trim() || this.SpaceBetweenLetters != this.OldSpaceBetweenLetters)
        {
            this.OldSpaceBetweenLetters = this.SpaceBetweenLetters;
            this.OldString = this.TextToBeRendered;
            this.GenerateText();
        }
	}

    void GenerateText()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(this.transform.GetChild(i).gameObject);
        }

        char[] characters = this.TextToBeRendered.ToCharArray();
        int count = 0;

        foreach (var character in characters)
        {
            Transform letter = null;
            foreach (var prefix in this.Prefix)
            {
                letter = AvailableLetters.transform.Find(prefix + character.ToString().ToUpper() + this.Postfix);
                if (letter != null)
                {
                    break;
                }
            }

            if (letter != null)
            {
                GameObject renderedLetter = Instantiate(letter.gameObject, this.transform.position + (Vector3.right * this.SpaceBetweenLetters) * count, this.transform.rotation);
                renderedLetter.SetActive(true);
                renderedLetter.transform.parent = this.transform;
            }

            count++;
        }
    }
}
