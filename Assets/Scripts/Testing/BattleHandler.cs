using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] Button dmgButton;
    [SerializeField] Button healButton;
    [SerializeField] int hpMax = 100;
    [SerializeField] int currentHP;
    [SerializeField] int damage = 28;
    [SerializeField][Range(1, 3)] int damageStep = 1;
    [SerializeField] int healing = 40;
    [SerializeField][Range(1, 3)] int healingStep = 1;

    float delay;

    bool occupied = false;

    WaitForSeconds wait;

    // Start is called before the first frame update
    void Start()
    {
        hpBar.minValue = 0;
        hpBar.maxValue = hpMax;
        currentHP = hpMax;
        delay = 0.02f;
        wait = new WaitForSeconds(delay);


        dmgButton.onClick.AddListener(() => Damage());
        healButton.onClick.AddListener(() => Heal());
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = currentHP.ToString() + " / " + hpMax;
        hpBar.value = currentHP;
        wait = new WaitForSeconds(delay);

        if(damageStep > 5)
        {
            damageStep = 5;
        }

        if(healingStep > 5)
        {
            healingStep = 5;
        }

        if (occupied)
        {
            dmgButton.enabled = false;
            healButton.enabled = false;
        }
        else
        {
            dmgButton.enabled = true;
            healButton.enabled = true;
            StopCoroutine(LooseHP());
            StopCoroutine(Healing());
        }

    }

    public void Damage()
    {
        StartCoroutine(LooseHP());
    }

    public void Heal()
    {
        StartCoroutine(Healing());
    }


    IEnumerator LooseHP()
    {
        if(currentHP > 0)
        {
            int finalHP = 0;
            if(currentHP - damage > 0)
            {
                finalHP = currentHP - damage;
            }
            occupied = true;
            for (int i = 0; i < damage / damageStep; i++)
            {
                if(currentHP >= damageStep)
                {
                    currentHP -= damageStep;
                    if (i == (damage / damageStep) - 1)
                    {
                        currentHP = finalHP;
                        occupied = false;
                    }
                    yield return wait;
                }
                else
                {
                    currentHP = 0;
                    occupied = false;
                }
            }
        }
    }

    IEnumerator Healing()
    {
        if(currentHP != hpMax)
        {
            int finalHP = hpMax;
            if (currentHP + healing < hpMax)
            {
                finalHP = currentHP + healing;
            }
            occupied = true;
            for (int i = 0; i < healing / healingStep; i++)
            {
                if(currentHP <= hpMax - healingStep)
                {
                    currentHP += healingStep;
                    if (i == (healing / healingStep) - 1)
                    {
                        currentHP = finalHP;
                        occupied = false;
                    }
                    yield return wait;
                }
                else
                {
                    currentHP = hpMax;
                    occupied = false;
                }
            }  
        }
    }
}
