using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTrigger : PickUp {

    public SuperAbility.Abilities type;
    public GameObject effect;
    private GameObject instEffect = null;


    private IEnumerator coroutine = null;

    public float durationOfEffect = 1f;
    

    private bool picked = false;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !picked)
        {
            PhaseController pc = collision.GetComponent<PhaseController>();
            pc.actualAbility = AbilityCreator.CreateAbility(type, pc);
            if (effect != null) effect.SetActive(false);
            picked = true;
            coroutine = Pickup(pc);
            StartCoroutine(coroutine);
        }
    }

    public override void Reset()
    {
        if(coroutine != null) StopCoroutine(coroutine);
        BonusEffect[] be = GetComponents<BonusEffect>();
        foreach(BonusEffect x in be)
        {
            x.Reset();
            picked = false;
        }
        if (instEffect != null) Destroy(instEffect);
    }

    public bool WasPickedUp()
    {
        return picked;
    }

    IEnumerator Pickup(PhaseController pc)
    {
        if (effect == null)
        {
            Debug.Log("Noeffect");
            yield return null;
        }
        else
        {
            instEffect = Instantiate(effect, transform.position, pc.transform.rotation);
            instEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(durationOfEffect);
            GameObject.Destroy(instEffect);
            wasPicked = true;
            GetComponent<SPickups>().canBeDestoryed = true;
            gameObject.SetActive(false);
            Debug.Log("OFF");
        }
    }
}
