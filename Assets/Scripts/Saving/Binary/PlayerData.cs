[System.Serializable]
/*
 Serialization is the automatic process of transforming data 
 structures or object states into a format that Unity can store and reconstruct later.

Serialization is the process of converting an object 
into a stream of bytes to store the object or transmit it to memory,
a database, or a file. Its main purpose is to save the state of an
object in order to be able to recreate it when needed. 
The reverse process is called deserialization

The serialization system is written in C++
*/
public class PlayerData
{
    //Data....Get from Game
    public string playerName;
    public int level;
    public string checkPoint;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;

    public PlayerData(PlayerHandler player)
    {
        playerName = player.name;
        level = 0;
        checkPoint = player.curCheckPoint.name;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;

        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;
    }
}
