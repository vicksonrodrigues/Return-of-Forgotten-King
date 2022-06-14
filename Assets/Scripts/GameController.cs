using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;

    public TMP_InputField textEntryField;
    public TextMeshProUGUI logText;
    public TextMeshProUGUI currentText;
    public Image locationBackground;//UI backgroundImage

    public Action[] actions;

    [TextArea]
    public string introText;

	// Use this for initialization
	void Start ()
    {
        logText.text = introText;
        DisplayLocation();
        DisplayBackground();
        textEntryField.ActivateInputField();
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}


    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void DisplayBackground ()
    {
        
        Sprite currentImage = player.currentLocation.backgroundImage ;
        locationBackground.GetComponent<Image>().sprite = currentImage;
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description+"\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();
        if (additive)
            currentText.text = currentText.text + "\n" + description;
        else
            currentText.text = description;
    }



    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();

    }

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#008000ff>" + textEntryField.text+"</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = {' '};
        string[] separatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length>1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens! (having trouble? Refer How To Play";
    }


}











