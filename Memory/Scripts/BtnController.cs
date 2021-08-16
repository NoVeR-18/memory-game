using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{
    private MenuController menu;
    public GameObject Wall;


    [SerializeField]
    private Btn btn;


    private Btn[] btns = new Btn[16];
    void Awake()
    {
        Wall.SetActive(false);
        menu = GetComponentInParent<MenuController>();
        for (var i = 0; i < btns.Length; i++)
        {
            btns[i] = Instantiate(btn, GetComponent<Transform>());
        }
    }
    private void OnEnable()
    {
        SetId();
    }
    private void OnDisable()
    {
        for (var i = 0; i < btns.Length; i++)
        {
            btns[i].button.interactable = true;
            btns[i].flag = false;
        }
    }

    public void SetId()
    {
        bool dublicate = false;
        for (var i = 1; i <= btns.Length / 2;)
        {
            var n = Random.Range(0, btns.Length);
            if (dublicate)
            {
                if (!btns[n].flag)
                {
                    btns[n].id = i;
                    btns[n].flag = true;
                    i++;
                    dublicate = false;
                    continue;
                }
            }
            if (!btns[n].flag)
            {
                btns[n].id = i;
                btns[n].flag = true;
                dublicate = true;
            }
        }
    }

    public void ActivateBtn(int id)
    {
        for (var i = 0; i < btns.Length; i++)
        {
            if (btns[i].id == id)
            {
                btns[i].Flip(0);
                btns[i].button.interactable = true;
            }
        }
    }
    public void DestroyBtn(int id)
    {
        for(var i = 0; i < btns.Length; i++) { 
            if(btns[i].id == id)
            {
                btns[i].flag = false;
                btns[i].button.interactable = false;
                menu.Check(btns);
            }
        }
    }
    

}
