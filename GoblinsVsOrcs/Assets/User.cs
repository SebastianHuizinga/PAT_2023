using System;

[Serializable]
public class User
{

    public string userName;
    public int enemiesKilled;
    public int moneySpent;
    public int towersBuilt;
    public int arrowsShot;
    public int levelReached;

    


    public User(string name, int enemies, int built, int money, int shot, int level)
    {
        userName = name;
        levelReached = level;
        towersBuilt = built;
        enemiesKilled = enemies;
        moneySpent = money;
        arrowsShot = shot;

    }
}
