using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    [SerializeField]
    public Sprite emptyHeart;

    [SerializeField]
    public Sprite halfHeart;

    [SerializeField]
    public Sprite fullHeart;

    public void SetHP(int hp)
    {
        if (hp >= 2)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = fullHeart;
        }
        else if (hp >= 1)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = halfHeart;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = emptyHeart;
        }

        if (hp >= 4)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = fullHeart;
        }
        else if (hp >= 3)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = halfHeart;
        }
        else
        {
            transform.GetChild(1).GetComponent<Image>().sprite = emptyHeart;
        }

        if (hp >= 6)
        {
            transform.GetChild(2).GetComponent<Image>().sprite = fullHeart;
        }
        else if (hp >= 5)
        {
            transform.GetChild(2).GetComponent<Image>().sprite = halfHeart;
        }
        else
        {
            transform.GetChild(2).GetComponent<Image>().sprite = emptyHeart;
        }
    }

}
