using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class noticeBoard : MonoBehaviour
{
    // disables object when the animation has stopped
    public void StopAnimation()
    {
        gameObject.SetActive(false);
    }

    // takes a string and displays it on the notice board
    public void DisplayWord(string text)
    {
        gameObject.SetActive(true); // enabling the object
        gameObject.GetComponent<TMP_Text>().text = text; // setting the text variable to the text from the function
        gameObject.GetComponent<Animator>().Play("On"); // starting the animation
    }
}
