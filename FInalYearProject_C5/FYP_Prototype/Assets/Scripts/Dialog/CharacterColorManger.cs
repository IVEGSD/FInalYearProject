using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorManger : MonoBehaviour {

    public Animator colorEffect;

    void Start()
    {
        colorEffect.SetBool("isBlack", false);
    }
    
    //public void turnToBlack()
    //{
    //    colorEffect.SetBool("isBlack", true);
    //}

    //public void turnToFull()
    //{
    //    colorEffect.SetBool("isBlack", false);
    //}
    
    public void ChangeBlack(bool isBlack)
    {
        if (isBlack)
        {
            colorEffect.SetBool("isBlack", true);
        }
        else
        {
            colorEffect.SetBool("isBlack", false);
        }
    }
}
