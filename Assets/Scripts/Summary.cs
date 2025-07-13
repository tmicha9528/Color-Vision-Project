using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class Summary : MonoBehaviour
{
    public TextMeshProUGUI yourTime;
    public TextMeshProUGUI yourPlays;
    public TextMeshProUGUI yourScore;
    // Start is called before the first frame update
    void Start()
    {
        double yTime = Level1.timeForSummary + Level2.timeForSummary + Level3.timeForSummary;
        yTime = System.Math.Round(yTime, 0);
        yourTime.text = "Your Time: " + yTime + " \"";
        double yPlays = Level1.playsForSummary + Level2.playsForSummary + Level3.playsForSummary;
        yourPlays.text = "Your Plays: " + yPlays;
        
        double yScoreLv1 = Level1.savedTimeForSummary * Level1.savedPlaysForSummary * (Level1.matchPercentage/100);
        double yScoreLv2 = Level2.savedTimeForSummary * Level2.savedPlaysForSummary * (Level2.matchPercentage/100);
        double yScoreLv3 = Level3.savedTimeForSummary * Level3.savedPlaysForSummary * (Level3.matchPercentage/100);

        double yScore = yScoreLv1 + yScoreLv2 + yScoreLv3;
        yScore = System.Math.Round(yScore, 2);
        double score = 0;
        if(yScore >= 0 && yScore<= 199){
            score = 200;
        }
        else if(yScore >= 200 && yScore <= 249){
            score = 250;
        }
        else if(yScore >= 250  && yScore <= 349){
            score = 300;
        }
        else if(yScore >= 350 && yScore <= 399){
            score = 350;
        }
        else if(yScore >= 400 && yScore <= 449){
            score = 400;
        }
        else if(yScore >= 450 && yScore <= 499){
            score = 450;
        }
        else if(yScore >= 500 && yScore <= 599){
            score = 500;
        }
        else if(yScore >= 600 && yScore <= 699){
            score = 550;
        }
        else if(yScore >= 700 && yScore <= 799){
            score = 600;
        }
        else if(yScore >= 800 && yScore <= 899){
            score = 650;
        }
        else if(yScore >= 900 && yScore <= 1049){
            score = 700;
        }
        else if(yScore >= 1050 && yScore <= 1199){
            score = 750;
        }
        else if(yScore >= 1200 && yScore <= 1800){
            score = 800;
        }
        yourScore.text = "Overall Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
