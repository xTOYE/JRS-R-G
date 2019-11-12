using UnityEngine;
using UnityEngine.UI;

public class RadialHealth : MonoBehaviour
{
    public Image radialHealthIcon;
    public float curHealth, maxHealth;
    void HealthChange()
    {
        float amount = Mathf.Clamp01(curHealth/maxHealth);
        radialHealthIcon.fillAmount = amount;
    }
    void Update()
    { 
        HealthChange();
    }
}
