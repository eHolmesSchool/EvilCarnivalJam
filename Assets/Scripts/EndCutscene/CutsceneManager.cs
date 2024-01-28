using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Ending currentEnding;
    [SerializeField] public List<Sprite> tigerSprites;
    [SerializeField] public List<Sprite> axeSprites;
    [SerializeField] public List<Sprite> ringMasterSprites;
    [SerializeField] public List<Sprite> pacifistSprites;

    [SerializeField] public List<string> tigerTexts;
    [SerializeField] public List<string> axeTexts;
    [SerializeField] public List<string> ringTexts;
    [SerializeField] public List<string> pacifistTexts;

    public List<Sprite> currentSprites;
    public List<string> currentTexts;

    [SerializeField] public Image spriteDisp;
    [SerializeField] public TextMeshProUGUI textDisp;
    [SerializeField] public GameObject textDispObj;
    public int currentSlideNumb;
    public bool isTextRevealed = true;
    public int maxSlideCount;


    void Start()
    {
        if (EndMenuManager.currentEnding == EndMenuManager.Ending.Tiger)
        {
            currentEnding = Ending.Tiger;
        }
        else if (EndMenuManager.currentEnding == EndMenuManager.Ending.AxeMen)
        {
            currentEnding = Ending.AxeMen;
        }
        else if (EndMenuManager.currentEnding == EndMenuManager.Ending.RingMaster)
        {
            currentEnding = Ending.RingMaster;
        }
        else if (EndMenuManager.currentEnding == EndMenuManager.Ending.Pacifist)
        {
            currentEnding = Ending.Pacifist;
        }

        currentSlideNumb = 0;
        currentSprites = new List<Sprite>();
        currentTexts = new List<string>();

        if (currentEnding == Ending.Tiger)
        {
            currentSprites = tigerSprites;
            currentTexts = tigerTexts;
        }
        else if (currentEnding == Ending.AxeMen)
        {
            currentSprites = axeSprites;
            currentTexts = axeTexts;
        }
        else if (currentEnding == Ending.RingMaster)
        {
            currentSprites = ringMasterSprites;
            currentTexts = ringTexts;
        }
        else if (currentEnding == Ending.Pacifist)
        {
            currentSprites = pacifistSprites;
            currentTexts = pacifistTexts;
        }

        maxSlideCount = currentSprites.Count;
    }



    void FixedUpdate()
    {
        
        textDispObj.SetActive(isTextRevealed);
        textDisp.text = currentTexts[currentSlideNumb];
        spriteDisp.sprite = currentSprites[currentSlideNumb];
    }

    public void TextToggle()
    {
        if (isTextRevealed)
        {
            isTextRevealed = false;
        }
        else
        {
            isTextRevealed = true;
        }
    }

    public void NextSlide()
    {
        if (currentSlideNumb == maxSlideCount-1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            currentSlideNumb++;
        }
    }

    public enum Ending
    {
        Tiger,
        AxeMen,
        RingMaster,
        Pacifist
    }
}
