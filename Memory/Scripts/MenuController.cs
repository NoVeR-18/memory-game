using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static int points = 0;

    private int maxPoints;

    [SerializeField]
    private Text Timer;
    [SerializeField]
    private Text Steps;
    [SerializeField]
    private Text winText;
    [SerializeField]
    private GameObject Game;
    [SerializeField]
    private GameObject WinMenu;
    [SerializeField]
    private GameObject LoseMenu;
    public static float time;
    private void OnEnable()
    {
        points = 0;
        time = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        Timer.text = Mathf.Round(time).ToString();
        Steps.text = Mathf.Abs(maxPoints-points).ToString();

        if (points == maxPoints && maxPoints!=0)
        {
            LoseMenu.SetActive(true);
            Game.SetActive(false);
        }
    }
    public void Retry()
    {
        points = 0;
        time = 0;
        Game.SetActive(false);
        Game.SetActive(true);
    }
    public void SetDifficult(int n)
    {
        switch (n)
        {
            case 0:
                maxPoints = 0;
                break;
            case 1:
                maxPoints = 24;
                    break;
            case 2:
                maxPoints = 16;
                    break;
            case 3:
                maxPoints = 8;
                    break;

        }
    }
    public void Check(Btn[] btns)
    {
        for (var i = 0; i < btns.Length; i++)
        {
            if (btns[i].flag)
                return;
        }
        WinMenu.SetActive(true);
        GameObject.Find("Game").SetActive(false);
        winText.text = ("Steps to win:" + MenuController.points);
    }
}
