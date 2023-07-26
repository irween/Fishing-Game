using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noticeBoardController : MonoBehaviour
{
    private Animation noticeBoardAnimations;

    // Start is called before the first frame update
    void Start()
    {
        noticeBoardAnimations = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        noticeBoardAnimations.Play("NoticeBoardOn");
    }

    public void NoticeBoardOff()
    {
        noticeBoardAnimations.Play("NoticeBoardOff");
    }

}
