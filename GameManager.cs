//경험치와 레벨업시 무기 선택지에 관련된 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider EXP;
    [SerializeField] GameObject levelUP;
    public float expPoint = 0f;
    [SerializeField]Image firstbutton;
    [SerializeField]Image secondButton;
    ThrowWeapon throwWeapon;

    [Header("Image")]
    [SerializeField] Sprite Axe;
    [SerializeField] Sprite Spear;
    bool SelectOnce = true;
    int index1;
    int index2;
    void Start()
    {
        throwWeapon = FindObjectOfType<ThrowWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        EXP.value = expPoint/100f;  //경험치바 업데이트
        if(EXP.value == 1 && SelectOnce) //이 밑으로는 인덱스 번호 > #define AXE 1 같은 느낌으로 무기마다 정수값을 받아서 표현
        {
            SelectOnce = false;  
            Time.timeScale = 0f;
            levelUP.SetActive(true);
            SetButton();
        }
    }

    void SetRandomIndex()
    {
        index1 = Random.Range(0, 2);
        while(true)
        {
            index2 = Random.Range(0, 2);
            if(index2 != index1)
            return;
        }
    }

    void SetButton()
    {
        SetRandomIndex();
        if(index1 == 0)
        {
            firstbutton.sprite = Axe; secondButton.sprite = Spear;
        }
        else if(index1 == 1)
        {
            firstbutton.sprite = Spear; secondButton.sprite = Axe;
        }
    }
    public void ChooseFirst()
    {
        if(index1 == 0)
        throwWeapon.AxeLevel += 1;
        else if(index1 == 1)
        throwWeapon.SpearLevel += 1;
        CloseUI();
    }

    public void ChooseSecond()
    {
        if(index2 == 0)
        throwWeapon.AxeLevel += 1;
        else if(index2 == 1)
        throwWeapon.SpearLevel += 1;
        CloseUI();
    }

    void CloseUI()
    {
        Time.timeScale = 1f;
        levelUP.SetActive(false);
        expPoint = 0;
        SelectOnce = true;
    }
}
