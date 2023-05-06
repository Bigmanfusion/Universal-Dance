using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float Goodhits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, GoodText, missesText, rankText, FinalScoreText;    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";

        resultsScreen.SetActive(false);

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        
            GoodText.text = "" + Goodhits;
            missesText.text = "" + missedHits;

            float totalHit = Goodhits;
            float percentHit = (totalHit / totalNotes) * 100f;

            percentHitText.text = percentHit.ToString("F1") + "%";

            string rankVal = "F";

            if(percentHit > 40)
            {
                rankVal = "D";
                if(percentHit > 55)
                {

                    rankVal = "C"; 
                    if(percentHit > 70)
                    {
                        rankVal = "B";
                        if(percentHit > 85)
                        {
                            rankVal = "A";
                            if(percentHit > 95)
                            {

                                rankVal = "S";  
                            }
                        }
                    }
                }
            }

            rankText.text = rankVal;

            FinalScoreText.text = currentScore.ToString();

       
    }

    public void NoteHit()
    {

        Debug.Log("Hit On Time");

        currentScore += scorePerNote;

        scoreText.text = "Score:" + currentScore;

        Goodhits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        missedHits++;

    }
}
