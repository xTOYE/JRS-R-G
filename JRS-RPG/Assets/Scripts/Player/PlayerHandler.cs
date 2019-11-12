using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHandler : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerStats
    {
        public string name;
        public int value;
    };

    [Header("Value Variables")]
    public float curHealth;
    public float curMana, curStamina, maxHealth, maxMana, maxStamina, healRate;
    public PlayerStats[] stats;
    [Header("Value Variables")]
    public Slider healthBar;
    public Slider manaBar, staminaBar;
    [Header("Damage Effect Variables")]
    public Image damageImage;
    public Image deathImage;
    public Text text;
    public AudioClip deathClip;
    public float flashSpeed = 5;
    public Color flashColour = new Color(1, 0, 0, 0.2f);
    AudioSource playerAudio;
    public static bool isDead;
    bool damaged;
    bool canHeal;
    float healTimer;
    [Header("Check Point")]
    public Transform curCheckPoint;
    [Header("Save")]
    public PlayerSaveAndLoad saveAndLoad;
    [Header("Custom")]
    public bool custom;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public CharacterClass characterClass;
    public string characterName;
    public string firstCheckPointName = "First CheckPoint";
    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!custom)
        {
            //Display Health
            if (healthBar.value != Mathf.Clamp01(curHealth / maxHealth))
            {
                curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
                healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
            }
            if (manaBar.value != Mathf.Clamp01(curMana / maxMana))
            {
                curMana = Mathf.Clamp(curMana, 0, maxMana);
                manaBar.value = Mathf.Clamp01(curMana / maxMana);
            }
            if (staminaBar.value != Mathf.Clamp01(curStamina / maxStamina))
            {
                curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
                staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
            }
            if (curHealth <= 0 && !isDead)
            {
                Death();
            }
#if UNITY_EDITOR
            //Damage
            if (Input.GetKeyDown(KeyCode.X))
            {
                damaged = true;
                curHealth -= 5;
            }
#endif

            if (damaged && !isDead)
            {
                damageImage.color = flashColour;
                damaged = false;
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            if (!canHeal && curHealth < maxHealth && curHealth > 0)
            {
                healTimer += Time.deltaTime;
                if (healTimer >= 5)
                {
                    canHeal = true;
                }
            }
        }       
    }
    private void LateUpdate()
    {
        if (curHealth < maxHealth && curHealth > 0 && canHeal)
        {
            HealOverTime();
        }
    }
    void Death()
    {
        //Set the death flag to this function isnt called again
        isDead = true;
        text.text = "";

        //Set the AudioSource to play the death clip
        playerAudio.clip = deathClip;
        playerAudio.Play();
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
        Invoke("DeathText", 2f);
        Invoke("ReviveText", 6f);
        Invoke("Revive", 9f);
    }
    void Revive()
    {
        text.text = "";
        isDead = false;
        curHealth = maxHealth;
        curMana = maxMana;
        curStamina = maxStamina;

        //more and rotate to spawn location
        this.transform.position = curCheckPoint.position;
        this.transform.rotation = curCheckPoint.rotation;

        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Revive");
    }
    void DeathText()
    {
        text.text = "You've Fallen in Battle...";
    }
    void ReviveText()
    {
        text.text = "...But the Gods have decided it isn't your time...";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            curCheckPoint = other.transform;
            healRate = 5;
            saveAndLoad.Save();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            healRate = 0;
        }
    }
    public void DamagePlayer(float damage)
    {
        damaged = true;
        curHealth -= damage;
        canHeal = false;
        healTimer = 0;
    }
    public void HealOverTime()
    {
        curHealth += Time.deltaTime * (healRate + stats[2].value);
    }
}
