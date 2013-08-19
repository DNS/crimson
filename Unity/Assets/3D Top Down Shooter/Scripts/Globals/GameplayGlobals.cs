public class GameplayGlobals 
{

	public static bool hasRifle = false;
	public static bool hasFlameThrower = false;
	public static bool hasShotgun = false;
	public static bool hasGlauncher;
	public static int enemyLimit = 30;
	public static int enemyCount = 0;
	public static int weaponType = 1;
	public static int killedZombies = 0;
	public static int fraggedZombies = 0;
	public static bool recieveOvertimeBonus = false;
    public static int dificultyMultiplier = 1;
	public static int shotGunAmmo = 0;
	public static int flameThrowerAmmo = 0;
	public static int miniGun = 0;
	public static int grenades = 0;
	public static int toNextStageKills = 50;
	public static bool survivalMode = false;
	public static bool completed = false;
	public static int cashinPockets = 0;
	
	public static void RestartGame()
	{
		hasRifle = false;
		hasFlameThrower = false;
		hasShotgun = false;
		hasGlauncher = false;
		weaponType = 1;
		dificultyMultiplier = 1;
		shotGunAmmo = 0;
		flameThrowerAmmo = 0;
		miniGun = 0;
		grenades = 0;
		toNextStageKills = 50;
		RestartGameplay();
	}
	
	public static void RestartGameplay()
	{
		enemyCount = 0;
		killedZombies = 0;
		fraggedZombies = 0;
		recieveOvertimeBonus = false;
		completed = false;
		cashinPockets = 0;
		toNextStageKills *= GlobalStats.Level;
	}
}
