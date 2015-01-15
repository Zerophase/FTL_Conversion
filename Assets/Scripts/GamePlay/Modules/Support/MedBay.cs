using UnityEngine;
using System.Collections;

public class MedBay : SupportModule
{
    //Need to figure out implementation of SaveCrew()
    private bool savingThrow = false;

    public MedBay()
    {
        moduleName = "Medbay";

        weaponSprite = Resources.Load<Texture>("Medbay");
    }

    public bool SaveCrew()
    {
        if (!savingThrow)
        {
            return savingThrow = true;
        }
        else
            return savingThrow = false;
    }

    //Call at end of combat.
    public void ResetSavingThrow()
    {
        savingThrow = false;
    }
}
