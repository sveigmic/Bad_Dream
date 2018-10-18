using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPickups : SavableObject {

    bool picked;

    public override void Save()
    {
        PickUp x = GetComponent<PickUp>();
        picked = x.wasPicked;
        if (picked) canBeDestoryed = true;
    }

    public override void Load()
    {
        PickUp x = GetComponent<PickUp>();
        x.wasPicked = picked;
        x.Reset();
        if (picked) x.gameObject.SetActive(false);
        else x.gameObject.SetActive(true);
    }
}
