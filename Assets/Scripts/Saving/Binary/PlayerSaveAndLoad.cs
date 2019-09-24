using UnityEngine;
public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
            //Save Binary Data
            Save();
        }
        else
        {
            //Load Binary shiz
            Load();
        }
    }
    void FirstLoad()
    {
        player.maxHealth = 100;
        player.maxMana = 100;
        player.maxStamina = 100;
        player.curCheckPoint = GameObject.Find("First CheckPoint").GetComponent<Transform>();

        player.curHealth = player.maxHealth;
        player.curMana = player.maxMana;
        player.curStamina = player.maxStamina;
   
        player.transform.position = new Vector3(1, 1, 1);
        player.transform.rotation = new Quaternion(0,0,0,0);
    }
    public void Save()
    {
        PlayerBinary.SavePlayerData(player);
    }
    public void Load()
    {
        PlayerData data = PlayerBinary.LoadData(player);
        player.name = data.playerName;
        player.curCheckPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
    }
}
