using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Normally General Game Settings like Sound
public class PlayerPrefsSave : MonoBehaviour
{
    public PlayerHandler player;
    float x, y, z;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            Load();
            PlayerPrefs.SetInt("Loaded", 0);
            //Save Binary Data
        }
        else
        {
            //Load Binary shiz
        }
    }
    public void Save()
    {
        //PlayerPrefs save Float with Key CurHealth and the players current health value
        PlayerPrefs.SetFloat("CurHealth", player.curHealth);
        PlayerPrefs.SetFloat("CurMana", player.curMana);
        PlayerPrefs.SetFloat("CurStamina", player.curStamina);
        //Position
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        //Rotation
        PlayerPrefs.SetFloat("PlayerRotX", player.transform.rotation.x);
        PlayerPrefs.SetFloat("PlayerRotY", player.transform.rotation.y);
        PlayerPrefs.SetFloat("PlayerRotZ", player.transform.rotation.z);
        PlayerPrefs.SetFloat("PlayerRotW", player.transform.rotation.w);
    }
    public void Load()
    {
        //players current health is set to PlayerPrefs saved float called CurHealth, else set it to MaxHealth
        player.curHealth = PlayerPrefs.GetFloat("CurHealth", player.maxHealth);
        player.curMana = PlayerPrefs.GetFloat("CurMana", player.maxMana);
        player.curStamina = PlayerPrefs.GetFloat("CurStamina", player.maxStamina);
        //Position
        /* x = PlayerPrefs.GetFloat("PlayerX", 1);
         y = PlayerPrefs.GetFloat("PlayerY", 1);
         z = PlayerPrefs.GetFloat("PlayerZ", 1);
         player.transform.position = new Vector3(x, y, z);*/
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX", 1), PlayerPrefs.GetFloat("PlayerY", 1), PlayerPrefs.GetFloat("PlayerZ", 1));
        player.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("PlayerRotX", 0), PlayerPrefs.GetFloat("PlayerRotY", 0), PlayerPrefs.GetFloat("PlayerRotZ", 0), PlayerPrefs.GetFloat("PlayerRotW", 0));

        //Rotation
    }
}
