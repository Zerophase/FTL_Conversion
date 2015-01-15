using UnityEngine;
using System.Collections;

public class FrontEndMenu : MonoBehaviour {

    public GUISkin menuSkin;
	private bool singlePlayerCampaign;
	private bool coOpCampaign;
	private bool tournamentMode;
	private bool settings;

    private bool reset;
    private bool resetButtons;

    private bool keyboardCustomization;
    private bool volume;
    private bool video;
    private bool gamma;

    private Rect singlePlayerRect;
    private Rect coOpRect;
    private Rect tournamentRect;
    private Rect settingsRect;

    private Rect buttonOne;
    private Rect buttonTwo;
    private Rect buttonThree;
    private Rect buttonFour;

    private float currentVolume = 50;
    private float currentVideo = 50;
    private float currentGamma = 50;

	private float x;
    private float y;
    private Vector2 resolution;

    private float horizontalAlignment = 100;
    private float verticalAligntment = 100;
    private float width = 150;
    private float height = 50;
    private float seperate = 70;

    private string singlePlayerText = "Single Player Campaign";
    private string coOpText = "Co-Op Campaign";
    private string tournamentModeText = "Tournament Mode";
    private string settingsText = "Settings";

    private string title;

    private GUIStyle slider = new GUIStyle();
    private GUIStyle thumb = new GUIStyle();

	void Start () 
	{
		singlePlayerCampaign = false;
		coOpCampaign = false;
		tournamentMode = false;
		settings = false;
        reset = false;
        resetButtons = false;


        title = "FTL";

        resolution = new Vector2(Screen.width, Screen.height);
        x = Screen.width / 960f;
        y = Screen.height / 600f;


        singlePlayerRect = new Rect(x * horizontalAlignment, y * verticalAligntment, 300, 50);
        coOpRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate), 300, 50);
        tournamentRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate * 2), 300, 50);
        settingsRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate * 3), 300, 50);

        buttonOne = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 50, width, height);
        buttonTwo = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 120, width, height);
        buttonThree = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 190, 300, height);
        buttonFour = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 260, 300, height);
	}

	void OnGUI()
	{
        GUI.skin = menuSkin;

        correctResolution();

        setUpToggles();

        resetRects();

        resetButtonPos();

        if (singlePlayerCampaign)
        {
            GUI.Button(buttonOne, "New Campaign");
            GUI.Button(buttonTwo, "Continue");

            reset = true;
        }

        if (coOpCampaign)
        {
            coOpRect = singlePlayerRect;

            buttonOne.x = 300;
            buttonTwo.x = 300;

            if(GUI.Button(buttonOne, "New Campaign"))
            {
                Application.LoadLevel(1);
            }
            GUI.Button(buttonTwo, "Continue");

            reset = true;
        }

        if (tournamentMode)
        {
            tournamentRect = singlePlayerRect;
            buttonOne.x = 300;
            buttonTwo.x = 300;

            GUI.Button(buttonOne, "1 v 1");
            GUI.Button(buttonTwo, "2 v 2");

            reset = true;
        }

        if (settings)
        {
            resetButtonPos();

            settingsRect = singlePlayerRect;

            buttonOne.width = 300;
            buttonTwo.width = 300;

            buttonOne.x = buttonTwo.x =  buttonThree.x = buttonFour.x = 220;
            if(!volume && !video && !gamma)
                assignKeys();

            if (!keyboardCustomization && !video && !gamma)
                changeVolume();

            if (!keyboardCustomization && !volume && !gamma)
                videoSettings();

            if (!keyboardCustomization && !volume && !video)
                gammaSettings();

            reset = true;
        }

        if (!settings)
        {
             keyboardCustomization = false;
             volume = false;
             video = false;
             gamma = false;
        }

	}

    void gammaSettings()
    {
        if (gamma)
            buttonFour.y = buttonOne.y;
        if (GUI.Button(buttonFour, "Gamma Corrections"))
        {
            if (!gamma)
            {
                gamma = true;
                resetButtons = false;
            }
            else
            {
                gamma = false;
                resetButtons = true;
            }
        }
        if (gamma)
        {
            currentGamma = GUI.HorizontalSlider(new Rect(singlePlayerRect.x + 50, singlePlayerRect.y + 100, 150, 25), currentGamma, 0, 100);
        }
    }

    void videoSettings()
    {
        if (video)
            buttonThree.y = buttonOne.y;

        if (GUI.Button(buttonThree, "Video Options"))
        {
            if (!video)
            {
                video = true;
                resetButtons = false;
            }
            else
            {
                video = false;
                resetButtons = true;
            }
        }

        if (video)
        {
            currentVideo = GUI.HorizontalSlider(new Rect(singlePlayerRect.x + 50, singlePlayerRect.y + 100, 150, 25), currentVideo, 0, 100);
        }
    }

    void changeVolume()
    {
        if (volume)
            buttonTwo.y = buttonOne.y;
        if (GUI.Button(buttonTwo, "Sound Volumes"))
        {
            if (!volume)
            {
                volume = true;
                resetButtons = false;
            }
            else
            {
                volume = false;
                resetButtons = true;
            }
                
        }
        if (volume)
        {
            currentVolume = GUI.HorizontalSlider(new Rect(singlePlayerRect.x + 50, singlePlayerRect.y + 100, 150, 25), currentVolume, 0, 100);
        }
    }

    void assignKeys()
    {
        if (GUI.Button(buttonOne, "Customize Keyboard"))
        {
            if (!keyboardCustomization)
            {
                keyboardCustomization = true;
                resetButtons = false;
            }   
            else
            {
                keyboardCustomization = false;
                resetButtons = true;
            }
                
        }

        if (keyboardCustomization)
        {
            GUI.Button(buttonTwo, "Assign Keys");
        }
    }

    //Doesn't work for now, resorting to individual methods for each button in the mean time.
    void setToggleValue(bool singlePlayerCampaign, bool coOpCampaign, bool tournamentMode, bool settings)
    {
        this.singlePlayerCampaign = singlePlayerCampaign;
        this.coOpCampaign = coOpCampaign;
        this.tournamentMode = tournamentMode;
        this.settings = settings;
    }

    void resetButtonPos()
    {
        if (resetButtons) 
        {
            buttonOne = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 50, width, height);
            buttonTwo = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 120, width, height);
            buttonThree = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 190, 300, height);
            buttonFour = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 260, 300, height);
            
            resetButtons = false;
        }
    }

    void resetRects()
    {
        if (!singlePlayerCampaign && !coOpCampaign && !tournamentMode && !settings && reset)
        {
            singlePlayerRect = new Rect(x * horizontalAlignment, y * verticalAligntment, 300, 50);
            coOpRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate), 300, 50);
            tournamentRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate * 2), 300, 50);
            settingsRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate * 3), 300, 50);

            buttonOne = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 50, width, height);
            buttonTwo = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 120, width, height);
            buttonThree = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 190, 300, height);
            buttonFour = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 260, 300, height);

            reset = false;
        }
    }

    void setUpToggles()
    {
        if (!coOpCampaign && !tournamentMode && !settings)
        {
            setupSinglePlayerCampaign(GUI.Toggle(singlePlayerRect, singlePlayerCampaign, singlePlayerText));
        }

        if (!singlePlayerCampaign && !tournamentMode && !settings)
        {
            setupCoOpCampaign(GUI.Toggle(coOpRect, coOpCampaign, coOpText));
        }

        if (!singlePlayerCampaign && !coOpCampaign && !settings)
        {
            setupTournamentMode(GUI.Toggle(tournamentRect, tournamentMode, tournamentModeText));
        }

        if (!singlePlayerCampaign && !coOpCampaign && !tournamentMode)
        {
            setupSettings(GUI.Toggle(settingsRect, settings, settingsText));
        }
    }

    void setupSettings(bool newValue)
    {
        if (newValue)
        {
            singlePlayerCampaign = false;
            coOpCampaign = false;
            tournamentMode = false;
            settings = true;
        }
        else
            settings = false;
    }

    void setupTournamentMode(bool newValue)
    {
        if (newValue)
        {
            singlePlayerCampaign = false;
            coOpCampaign = false;
            tournamentMode = true;
            settings = false;
        }
        else
            tournamentMode = false;
    }

    void setupCoOpCampaign(bool newValue)
    {
        if (newValue)
        {
            singlePlayerCampaign = false;
            coOpCampaign = true;
            tournamentMode = false;
            settings = false;
        }
        else
            coOpCampaign = false;
    }

    void setupSinglePlayerCampaign(bool newValue)
    {
        if (newValue)
        {
            singlePlayerCampaign = true;
            coOpCampaign = false;
            tournamentMode = false;
            settings = false;
        }
        else
            singlePlayerCampaign = false;
    }

    void correctResolution()
    {
        if (Screen.width != resolution.x || Screen.height != resolution.y)
        {
            resolution = new Vector2(Screen.width, Screen.height);
            x = Screen.width / 960f;
            y = Screen.height / 600f;

            singlePlayerRect = new Rect(x * horizontalAlignment, y * verticalAligntment, 300, 50);
            coOpRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate), 300, 50);
            tournamentRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate * 2), 300, 50);
            settingsRect = new Rect(x * horizontalAlignment, (y * verticalAligntment + seperate * 3), 300, 50);

            buttonOne = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 50, width, height);
            buttonTwo = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 120, width, height);
            buttonThree = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 190, 300, height);
            buttonFour = new Rect(singlePlayerRect.x + 220, singlePlayerRect.y + 260, 300, height);
        }
    }
}
