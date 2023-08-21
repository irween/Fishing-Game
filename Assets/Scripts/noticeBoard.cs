using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class noticeBoard : MonoBehaviour
{
    public void StopAnimation()
    {
        gameObject.SetActive(false);
    }

    public void DisplayWord(string text)
    {
        gameObject.GetComponent<TMP_Text>().text = text;
        gameObject.GetComponent<Animator>().Play("On");
    }
}
