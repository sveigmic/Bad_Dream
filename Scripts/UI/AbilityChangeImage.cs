using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityChangeImage : MonoBehaviour {

    [System.Serializable]
    public struct AbilitiesImages
    {
       public SuperAbility.Abilities ability;
       public Sprite image;
    }

    public AbilitiesImages[] abilitiesImages;
    private Dictionary <SuperAbility.Abilities, Sprite> images;

    private void Start()
    {
        images = new Dictionary<SuperAbility.Abilities, Sprite>();
        foreach (AbilitiesImages x in abilitiesImages)
        {
            images.Add(x.ability, x.image);
        }
    }

    public void CallStart()
    {
        Start();
    }

    public void ChangeImage(SuperAbility.Abilities a)
    {
        Image img = GetComponent<Image>();
        img.sprite = images[a];
        img.color = Color.white;
    }

    public void ClearImage()
    {
        Image img = GetComponent<Image>();
        img.sprite = null;
        img.color = Color.clear;
    }

}
