using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBarMime : MonoBehaviour
{
    public Image damageBar;

 
    public void UpdateDamage(float fraction)
    {
        damageBar.fillAmount = fraction;
    }
}
