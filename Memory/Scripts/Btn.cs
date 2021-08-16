using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    //нужно для инициализации кнопок
    [HideInInspector]
    public int id;
    [HideInInspector]
    public bool flag = false;
    //сравниваемая кнопка
    public static int activeId = 0;
    
    public Button button;
    private BtnController btnController;

    public Sprite[] sprites = new Sprite[9];

    private void Start()
    { 
        btnController = GetComponentInParent<BtnController>();
        button = GetComponent<Button>();
        button.image.sprite = sprites[id];
        btnController.Wall.SetActive(true);
        Invoke("SwapOnStart", 1.5f);
    }
    private void OnEnable()
    { 
        btnController = GetComponentInParent<BtnController>();
        button = GetComponent<Button>();
        button.image.sprite = sprites[id];
        btnController.Wall.SetActive(true);
        Invoke("SwapOnStart", 1.5f);
    }

    private void SwapOnStart()
    {
        button.image.sprite = sprites[0];
        btnController.Wall.SetActive(false);
    }

    public void OnClick()
    {
        btnController.Wall.SetActive(true);
        button.interactable = false;
        Flip(id);
        Invoke("Check", 0.5f);
    }
    private void Check()
    {
        if (activeId == 0)
        {
            activeId = id;
            btnController.Wall.SetActive(false);
        }
        else if (activeId == id)
        {
            MenuController.points++;
            btnController.DestroyBtn(id);
            btnController.Wall.SetActive(false);
            activeId = 0;
        }
        else if (activeId != id)
        {
            btnController.ActivateBtn(activeId);
            btnController.ActivateBtn(id);
            activeId = 0;
            MenuController.points++;
            btnController.Wall.SetActive(false);
        }
    }
    public void Flip(int id)
    {
        button.image.sprite = sprites[id];
    }
    

}
