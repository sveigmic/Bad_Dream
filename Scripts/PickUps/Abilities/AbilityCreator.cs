using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityCreator {


    public static SuperAbility CreateAbility(SuperAbility.Abilities ab, PhaseController p)
    {
        p.abilityImage.ChangeImage(ab);
        switch (ab)
        {
            case SuperAbility.Abilities.GravitySwap:
                return new GravitySwap(p, ab);
            case SuperAbility.Abilities.MagneticBoots:
                return new MagneticBoots(p, ab);
        }
        return new GravitySwap(p, ab);
    }
}
