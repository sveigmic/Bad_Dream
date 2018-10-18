using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointMaster : MonoBehaviour {

    private static CheckPointMaster instance;
    public Checkpoint checkPoint = null;

    public GameMasterPhases gameMaster;
    public List<SavableObject> savableObjects;

	void Awake () {
        savableObjects = new List<SavableObject>();
        instance = this;
        checkPoint = null;
	}
	
    public void AddCheckPoint(Checkpoint _chechPoint)
    {
        List<SavableObject> toRemove = new List<SavableObject>();
        if(checkPoint != null) Destroy(checkPoint.gameObject);
        checkPoint = _chechPoint;
        foreach (SavableObject x in savableObjects)
        {
            if (x.canBeDestoryed)
            {
                toRemove.Add(x);
            }
            else x.Save();
        }
        
        foreach(SavableObject x in toRemove)
        {
            savableObjects.Remove(x);
            Destroy(x.gameObject);
        }
    }

    public IEnumerator LoadCheckPoint()
    {
        yield return new WaitForEndOfFrame();
        foreach (SavableObject x in savableObjects) x.Load();
        gameMaster.GameOverShow(false);
    }

    public static CheckPointMaster Instance()
    {
        return instance;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(LoadCheckPoint());
        }
    }

    public bool ExistCheckPoint()
    {
        return checkPoint != null;
    }
}
