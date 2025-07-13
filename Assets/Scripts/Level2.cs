using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class Level2 : MonoBehaviour
{
    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;
    public Image imageObject;

    public TextMeshProUGUI goalText;
    public Image goalImage;

    private int goalRed;
    private int goalBlue; 
    private int goalGreen;

    private Color colorRed;
    private Color colorBlue;
    private Color colorGreen;

    private int redSliderVal;
    private int greenSliderVal;
    private int blueSliderVal;

    private int attemptsCounter = 1;
    public static int playsForSummary = 5;
    public static int savedPlaysForSummary = 0;
    private bool levelUnlocked = false;

    public TextMeshProUGUI redText;
    public TextMeshProUGUI greenText;
    public TextMeshProUGUI blueText;

    public TextMeshProUGUI attempts;
    public Button next;
    public Button match;

    public TextMeshProUGUI timer;
    private float timeValue = 120;
    public static float timeForSummary = 120;
    public static float savedTimeForSummary = 0;

    public static double matchPercentage = 0;
 
    public void ColorCompare()
    {
        double myDistance = Math.Sqrt(Math.Pow(goalRed-redSliderVal, 2) + Math.Pow(goalGreen-greenSliderVal, 2));
        double maxDistance = Math.Sqrt(2*255*255);
        double percentageDiff = 100 * (myDistance/maxDistance);
        percentageDiff = System.Math.Round(percentageDiff,1);
        matchPercentage = 100 - percentageDiff;
        if(matchPercentage == 100){
            goalText.text = "Perfect Match!";
            sliderRed.interactable = false;
            sliderGreen.interactable = false;
            next.interactable = true;
            levelUnlocked = true;
        }
        else{
            goalText.text = "You have a " + matchPercentage.ToString() + "% match";
        }
        attemptsCounter++;
        if(levelUnlocked == false){
            attempts.text = "Play: " + attemptsCounter + " of 5";
        }else{
            attempts.text = "Proceed to next Level";
        }
    }

    public void RestartLevel()
    {
        sliderRed.interactable = true;
        sliderGreen.interactable = true;
        sliderRed.value = 0;
        sliderGreen.value = 0;
        goalRed = Random.Range(0, 51) * 5;
        goalBlue = Random.Range(0, 51) * 5;
        goalGreen = Random.Range(0, 51) * 5;
        sliderBlue.value = goalBlue / 5;
        goalImage.color = new Color32((byte) goalRed, (byte) goalGreen, (byte) goalBlue, 255);
        goalText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        goalRed = Random.Range(0, 51) * 5;
        goalBlue = Random.Range(0, 51) * 5;
        goalGreen = Random.Range(0, 51) * 5;
        goalImage.color = new Color32((byte) goalRed, (byte) goalGreen, (byte) goalBlue, 255);

        sliderBlue.interactable = false;
        sliderBlue.value = goalBlue / 5;
        colorBlue = new Color32(0, 0, (byte) goalBlue, 255);
        next.interactable = false;
        sliderBlue.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = colorBlue;
        redText.text = "";
    }

    public void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if(seconds < 10){
            timer.text = minutes.ToString() + ":0" + seconds.ToString();
        }else{
            timer.text = minutes.ToString() + ":" + seconds.ToString();
        }
        if(timeToDisplay <= 10){
            timer.color = new Color32(202, 58, 60, 255);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(redSliderVal < 10){
            redText.text = "00" + redSliderVal;
        }else if(redSliderVal < 100){
            redText.text = "0" + redSliderVal;
        }else{
            redText.text = redSliderVal.ToString();
        }

        if(greenSliderVal < 10){
            greenText.text = "00" + greenSliderVal;
        }else if(greenSliderVal < 100){
            greenText.text = "0" + greenSliderVal;
        }else{
            greenText.text = greenSliderVal.ToString();
        }

        if(goalBlue < 10){
            blueText.text = "00" + goalBlue;
        }else if(goalBlue < 100){
            blueText.text = "0" + goalBlue;
        }else{
            blueText.text = goalBlue.ToString();
        }
        redSliderVal = (int) sliderRed.value * 5;
        greenSliderVal = (int) sliderGreen.value * 5;
        
        imageObject.color = new Color32((byte) redSliderVal, (byte) greenSliderVal, (byte) goalBlue, 255);
        
        colorRed = new Color32((byte) redSliderVal, 0, 0, 255);
        sliderRed.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = colorRed;
        
        colorGreen = new Color32(0, (byte) greenSliderVal, 0, 255);
        sliderGreen.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = colorGreen;

        if(attemptsCounter > 5 && levelUnlocked == false){
            attempts.text = "No more plays";
            sliderRed.interactable = false;
            sliderGreen.interactable = false;
            match.interactable = false;
            //next.interactable = true;
        }
        if(attemptsCounter > 2 && levelUnlocked == false){
            next.interactable = true;
        }
        if(levelUnlocked == false && timeValue > 0 && attemptsCounter <= 5){
            timeValue = timeValue - Time.deltaTime;
        }
        else if(levelUnlocked == false && timeValue <= 0){
            timeValue = 0;
        }
        if(levelUnlocked == false && timeValue == 0){
            attempts.text = "Out of time";
            sliderRed.interactable = false;
            sliderGreen.interactable = false;
            match.interactable = false;
            next.interactable = true;
        }
        if(next.interactable == true){
            Color32 nextButtonGreen = new Color32(43, 212,103,255);
            next.GetComponent<Image>().color = nextButtonGreen;
        }
        timeForSummary = 120 - timeValue;
        savedTimeForSummary = timeValue;
        playsForSummary = attemptsCounter - 1;
        savedPlaysForSummary = 5 - playsForSummary;
        DisplayTime(timeValue);
    }
}
