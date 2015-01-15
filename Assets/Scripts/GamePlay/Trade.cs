using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Trade : MonoBehaviour, IObserver
{
    List<WeaponModule> weaponsForSale = new List<WeaponModule>();
    List<SupportModule> supportModulesForSale = new List<SupportModule>();

    //Not Used
    WeaponModule[] weaponModules = new WeaponModule[3];
    public static WeaponModule TempWeaponModule;

    //Use these
    LaserCannon laserCannon;
    BurstCannon burstCannon;
    MissileLauncher missileLauncher;

    MedBay medBay;
    AncientAlienDevice ancientAlienDevice;
    DefenseDrone defenseDrone;
    OffenseDrone offenseDrone;

    private int iterator = 0;
    public static bool Trading = false;

    Player player;
    Ship ship;

    private Rect weaponModuleRect;
    private Rect supportModuleRect;

    private float x;
    private float y;

    private Module.Quality systemQuality;

	// Use this for initialization
	void Start () 
    {

        Resolution.Instance.CorrectResolution();
        
        if (Resolution.Instance != null)
        {
            x = Resolution.Instance.X;
            y = Resolution.Instance.Y;
        }

        player = FindObjectOfType<Player>();

        laserCannon = ScriptableObject.CreateInstance<LaserCannon>();
        burstCannon = ScriptableObject.CreateInstance<BurstCannon>();
        missileLauncher = ScriptableObject.CreateInstance<MissileLauncher>();
        
        weaponsForSale.Add(laserCannon);
        
        weaponsForSale.Add(burstCannon);
        
        weaponsForSale.Add(missileLauncher);

        medBay = ScriptableObject.CreateInstance<MedBay>();
        ancientAlienDevice = ScriptableObject.CreateInstance<AncientAlienDevice>();
        defenseDrone = ScriptableObject.CreateInstance<DefenseDrone>();
        offenseDrone = ScriptableObject.CreateInstance<OffenseDrone>();

        supportModulesForSale.Add(medBay);
        supportModulesForSale.Add(ancientAlienDevice);
        supportModulesForSale.Add(defenseDrone);
        supportModulesForSale.Add(offenseDrone);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Trading == true)
        {
            player.Attach(this);
        }
        else if(Trading == false && ship != null)
        {
            player.Detach(this);
        }

        //TODO Add logic for checking board change.
        if (Boards.MapSwith)
        {
            switch (Boards.MapNumber)
            {
                case 0:
                    systemQuality = Module.Quality.LOW;
                    break;
                case 1:
                    systemQuality = Module.Quality.NORMAL;
                    break;
                case 2:
                    systemQuality = Module.Quality.HIGH;
                    break;
                default:
                    Debug.Log("Not switching weapon quality in trade.");
                break;
            }

            Boards.MapSwith = false;
        }
	}

    void OnGUI()
    {
        if (Trading)
        {
            //TODO rework for a more generic solution
            //Might break if player has all of the weapons.
            if ( weaponModuleRect.width == 0) 
            {
                weaponModuleRect = new Rect( x * 200f, y * 50f, 200f * weaponsForSale.Count, 282f);
            }

            GUILayout.BeginArea(weaponModuleRect);
            GUILayout.BeginHorizontal();

            for (int i = 0; i < weaponsForSale.Count; i++) 
            {
                if(GUILayout.Button(weaponsForSale.ElementAt<WeaponModule>(i).WeaponSprite))
                {
                    if (ship.WeaponModules.Equals(weaponsForSale.ElementAt<WeaponModule>(i))) 
                    {
                        break;    
                    }

                    if(ship.WeaponModules.ElementAt<WeaponModule>(i).CurrentQuality < 
                            ship.WeaponModules.ElementAt<WeaponModule>(i).CurrentQuality)
                    {
                        ship.WeaponModules.ElementAt<WeaponModule>(i).ChangeQuality(systemQuality);
                    }
                    else if(!ship.WeaponModules.Contains(weaponsForSale.ElementAt<WeaponModule>(i)))
                    {
                        if (player.XP >= 2) 
                        {
                            ship.AddModule(weaponsForSale.ElementAt<WeaponModule>(i));
                            //TODO implement all gear costs.
                            player.XP -= 2;
                        }
                    }
                        
                }
            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            if (supportModuleRect.width == 0) 
            {
                supportModuleRect = new Rect(x * 200f, y * 250f, 200f * supportModulesForSale.Count, 282f);
            }

            GUILayout.BeginArea(supportModuleRect);
            GUILayout.BeginHorizontal();

            for (int i = 0; i < supportModulesForSale.Count; i++) 
            {
                if (GUILayout.Button(supportModulesForSale.ElementAt<SupportModule>(i).WeaponSprite)
                    && !ship.SupportModules.Contains(supportModulesForSale.ElementAt<SupportModule>(i))) 
                {
                    if (player.XP >= 2) 
                    {
                        ship.AddModule(supportModulesForSale.ElementAt<SupportModule>(i));
                        player.XP -= 2;
                    }
                }
            }

            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            if (GUI.Button( new Rect(x * 450f, y * 450f, 100, 50), "End trade")) 
            {
                ship = null;
                Trading = false;
            }
        }
    }

    public void ObserverUpdate(object sender, object message)
    {
        if (sender is Player)
        {
            if (ship == null) 
                ship = ((Player)sender).playerShip;
        }
    }
}
