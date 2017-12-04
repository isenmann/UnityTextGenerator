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
        if (this.OldString == this.TextToBeRendered.Trim() &&
            this.SpaceBetweenLetters == this.OldSpaceBetweenLetters)
        {
            return;
        }

        this.OldSpaceBetweenLetters = this.SpaceBetweenLetters;
        this.OldString = this.TextToBeRendered;
        this.GenerateText();
    }

    private void GenerateText()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(this.transform.GetChild(i).gameObject);
        }

        var characters = this.TextToBeRendered.ToCharArray();

        foreach (var character in characters)
        {
            Transform letter = null;

            if (this.Prefix.Length > 0)
            {
                foreach (var prefix in this.Prefix)
                {
                    letter = this.AvailableLetters.transform.Find(prefix + character + this.Postfix);
                    if (letter != null)
                    {
                        break;
                    }
                }
            }
            else
            {
                letter = this.AvailableLetters.transform.Find(character + this.Postfix);
            }

            if (letter == null)
            {
                continue;
            }

            GameObject newLetterToRender = null;

            if (this.transform.childCount > 0)
            {
                Vector3 position = this.transform.GetChild(this.transform.childCount - 1).position;
                Collider colliderPrevious = this.transform.GetChild(this.transform.childCount - 1).gameObject.GetComponent<Collider>();

                newLetterToRender = Instantiate(letter.gameObject, this.transform.position, this.transform.rotation);
                newLetterToRender.transform.SetParent(this.transform, true);
                newLetterToRender.SetActive(true);

                Collider colliderNext = newLetterToRender.gameObject.GetComponent<Collider>();
                position.x = position.x + colliderPrevious.bounds.extents.x + colliderNext.bounds.extents.x + this.SpaceBetweenLetters;

                newLetterToRender.transform.position = position;
            }
            else
            {
                newLetterToRender = Instantiate(letter.gameObject, this.transform.position + (Vector3.right * this.SpaceBetweenLetters), this.transform.rotation);
                newLetterToRender.SetActive(true);
                newLetterToRender.transform.SetParent(this.transform, true);
            }
        }
    }
}
