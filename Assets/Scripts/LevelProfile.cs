using Player;
using UnityEngine;
using Visual;

public class LevelProfile : MonoBehaviour
{
    public GameObject LevelRoot;
    public BallController Ball;
    public Camera Camera;
    public ClickFeedbackController ClickFeedback;
    public bool IsGameLevel;
    
    private LevelManager mManager;

    private void Awake()
    {
        mManager = LevelManager.GetManager();
        mManager.ReportLevelChanged(this);
    }

    public void CloseLevel()
    {
        LevelRoot.SetActive(false);
        gameObject.SetActive(false);
        mManager.ReportNoLevel();
    }

}
