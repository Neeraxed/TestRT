using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterScroll : MonoBehaviour
{
    private string[] numbersArray = new string[]{ "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    private TextMeshProUGUI numberText;
    private int currentnumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        numberText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        numberText.text = numbersArray[currentnumber];
    }

    public void increment()
    {
        if (currentnumber < 25) {
            currentnumber++;
        } else
        {
            currentnumber = 0;
        }
        numberText.text = numbersArray[currentnumber];
    }

    public void decrement()
    {
        if (currentnumber > 0)
        {
            currentnumber--;
        }
        else
        {
            currentnumber = 25;
        }
        numberText.text = numbersArray[currentnumber];
    }

    public string getLetter()
    {
        return numbersArray[currentnumber];
    }

    public void setLetter(int letter)
    {
        currentnumber = letter;
        numberText.text = numbersArray[currentnumber];
    }
}
