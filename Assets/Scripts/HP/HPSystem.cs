using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnDead;

    private List<HP> hpList;
    public HPSystem(int hpAmount)
    {
        hpList = new List<HP>();
        for (int i = 0; i < hpAmount; i++)
        {
            HP hp = new HP(4);
            hpList.Add(hp);
        }

    }

    public List<HP> GetHPList()
    {
        return hpList;
    }

    public void Damage(int damageAmount)
    {
        for (int i = hpList.Count - 1; i >= 0; i--)
        {
            HP hp = hpList[i];
            if (damageAmount > hp.GetFragmentAmount())
            {
                damageAmount -= hp.GetFragmentAmount();
                hp.Damage(hp.GetFragmentAmount());
            }
            else
            {
                hp.Damage(damageAmount);
                break;
            }
        }

        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);

        if (IsDead())
        {
            if (OnDead != null) OnDead(this, EventArgs.Empty);
        }
    }

    public bool IsDead()
    {
        return hpList[0].GetFragmentAmount() == 0;
    }

    //Представляет одно хп
    public class HP
    {
        private int fragments;
        
        public HP(int fragments)
        {
            this.fragments = fragments;
        }

        public int GetFragmentAmount()
        {
            return fragments;
        }
        
        public void SetFragments(int fragments)
        {
            this.fragments = fragments;
        }

        public void Damage(int damageAmount)
        {
            if (damageAmount >= fragments)
            {
                fragments = 0;
            }
            else
            {
                fragments -= damageAmount;
            }
        }
    }
}
