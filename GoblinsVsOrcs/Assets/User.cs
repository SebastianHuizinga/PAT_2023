using System;

[Serializable]
public class User
{
    // Public properties representing user attributes.
    public string userName; // User's name.
    public int enemiesKilled; // Number of enemies killed.
    public int moneySpent; // Amount of money spent.
    public int towersBuilt; // Number of towers built.
    public int arrowsShot; // Number of arrows shot.
    public int levelReached; // The level reached in the game.

    // Constructor to create a User object with specified attributes.
    public User(string name, int enemies, int built, int money, int shot, int level)
    {
        userName = name; // Initialize user name.
        levelReached = level; // Initialize level reached.
        towersBuilt = built; // Initialize towers built.
        enemiesKilled = enemies; // Initialize enemies killed.
        moneySpent = money; // Initialize money spent.
        arrowsShot = shot; // Initialize arrows shot.
    }
}