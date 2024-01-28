using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    [SerializeField] public List<Sprite> currentSprites;

    [SerializeField] public Image spriteDisp;
    public int currentSlideNumb;
    public int maxSlideCount;


    void Start()
    {
        currentSlideNumb = 0;

        maxSlideCount = currentSprites.Count;
    }

    void FixedUpdate()
    {
        spriteDisp.sprite = currentSprites[currentSlideNumb];
    }

    public void TextToggle()
    {
    }

    public void NextSlide()
    {
        if (currentSlideNumb == maxSlideCount - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            currentSlideNumb++;
        }
    }
} 
