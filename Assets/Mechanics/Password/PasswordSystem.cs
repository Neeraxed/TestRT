using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordSystem : MonoBehaviour
{
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;
    public GameObject Text;
    public GameObject Correct;
    public GameObject Wrong;

    private string[] alphabetArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    System.Random r = new System.Random();

    private string password = "";

    // Start is called before the first frame update
    void Start()
    {
        // Set up password
        int rInt;
        for (int i = 0; i < 7; i++) { 
            rInt = r.Next(0, 25);
            password += alphabetArray[rInt];
        }

        // Update StickyNote
        Text.GetComponent<TextMeshProUGUI>().text = password;
    }


    public void confirm()
    {
        string userAttempt = "";
        userAttempt += Number1.GetComponent<LetterScroll>().getLetter();
        userAttempt += Number2.GetComponent<LetterScroll>().getLetter();
        userAttempt += Number3.GetComponent<LetterScroll>().getLetter();
        userAttempt += Number4.GetComponent<LetterScroll>().getLetter();

        if (password.Equals(userAttempt))
        {
            Correct.GetComponent<Image>().color = new Color(1f,1f,1f);
            Wrong.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
            // Call Method Here for your Game to Progress
        } else {
            Correct.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
            Wrong.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
    }

    public void Reset()
    {
        Number1.GetComponent<LetterScroll>().setLetter(0);
        Number2.GetComponent<LetterScroll>().setLetter(0);
        Number3.GetComponent<LetterScroll>().setLetter(0);
        Number4.GetComponent<LetterScroll>().setLetter(0);
    }
}
