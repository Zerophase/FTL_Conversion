using UnityEngine;
using System.Collections;

public class Module : ScriptableObject
{
    public enum Quality { LOW = 0, NORMAL = 1, HIGH = 2 };
    protected Quality currentQuality;
    public Quality CurrentQuality { get {return currentQuality; } set { currentQuality = value; } }

    protected string moduleName;
    public string ModuleName { get { return moduleName; } }

    protected bool qualityHasChanged = false;

    protected Texture weaponSprite;
    public Texture WeaponSprite { get { return weaponSprite; } }
    //Figure out how to code special effects
    public Module()
    {
        currentQuality = Quality.LOW;
        moduleName = "Test Module";
    }
	
    public void ChangeQuality(Quality changeQuality)
    {
        if ((int)currentQuality < (int)changeQuality)
        {
            currentQuality = changeQuality;
            qualityHasChanged = true;
        }
        else
            qualityHasChanged = false;
    }
}
