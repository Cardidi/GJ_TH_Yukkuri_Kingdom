using System.Collections;
using System.Collections.Generic;
using PlayModule.Dialog;
using UI;
using UnityEngine;

public class LevelManager
{
    private static LevelManager mInstance;

    public static LevelManager GetManager()
    {
        if (mInstance == null)
        {
            mInstance = new LevelManager();
        }

        return mInstance;
    }

    private LevelProfile mProfile;

    public void ReportLevelChanged(LevelProfile profile)
    {
        mProfile = profile;
        HoldingUI.DoReset();
    }

    public void ReportNoLevel()
    {
        mProfile = null;
    }

    public bool TryGetProfile(out LevelProfile profile)
    {
        profile = mProfile;
        return mProfile != null;
    }

    public bool GameProfile => mProfile != null && mProfile.IsGameLevel;
    public DialogView DialogView { get; set; }
    public LoadingUIChaser LoadingUI { get; set; }
    public LevelPassUI PassUI { get; set; }
    public LevelFailedUI FailedUI { get; set; }
    public HoldingUI HoldingUI { get; set; }

}
