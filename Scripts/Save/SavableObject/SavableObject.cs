using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableObject : MonoBehaviour {

    public bool canBeDestoryed = false;

    private void Start()
    {
        CheckPointMaster.Instance().savableObjects.Add(this);
    }

    public virtual void Save()
    {

    }

    public virtual void Load()
    {

    }
}
