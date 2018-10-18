using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseController : MonoBehaviour
{
    [Header("Inputs")]
    public TouchManager touchManager;
    public VirtualJoystick joystick;

    [Header("Other objects")]
    public GameMasterPhases gameMaster;
    public DeadFog fogOfDead;
    public BoxCollider2D airColl;
    public AbilityChangeImage abilityImage;

    [HideInInspector]
    public Grounder grounder;

    [Header("Die Anchors")]
    public float bottomDieAnchor = 0;
    public float topDieAnchor = 50;

    [Header("Start phases")]
    public Phases startPhase;

    [HideInInspector]
    public Phase actualPhase;
    [HideInInspector]
    public Phases actPhaseEnum;


    [Header("Player attributes")]
    public Attributes attributes;

    [Header("Layers options")]

    public LayerMask boxLayer;

    [Header("Input active")]
    public bool activeInput = true;

    [HideInInspector]
    public List<ObjectAction> viableAction;
    [HideInInspector]
    public ObjectAction actualAction = null;
    [HideInInspector]
    public bool inAction = false;
    [HideInInspector]
    public List<Joint2D> joints;

    [HideInInspector]
    public List<HangObject> viableHangs;
    [HideInInspector]
    public HangObject actualHang;

    [HideInInspector]
    public List<SuperAbility> activeAbilities;
    [HideInInspector]
    public SuperAbility actualAbility = null; 

    private Queue<Phases> phaseQue;

    void Start()
    {
        phaseQue = new Queue<Phases>();
        CreatePhase(startPhase);
        grounder = GetComponent<Grounder>();
        viableAction = new List<ObjectAction>();
        viableHangs = new List<HangObject>();
        joints = new List<Joint2D>();
        activeAbilities = new List<SuperAbility>();
    }

    public void FixedUpdate()
    {
        actualPhase.FixedUpdate();
    }


    void Update()
    {
        UpdateAbilities();
        actualPhase.Update();
        if(phaseQue.Count > 0)
        {
            actualPhase.Leave();
            CreatePhase(phaseQue.Dequeue());
            phaseQue.Clear();
        }
    }

    public void SendRequestToChangePhase(Phases _phase)
    {
        Debug.Log("PhaseRequest");
        phaseQue.Enqueue(_phase);
    }

    public Phase CreatePhase(Phases _phase)
    {
        actPhaseEnum = _phase;
        switch(_phase)
        {
            case Phases.Normal:
                return actualPhase = new NormalPhase(this);
            case Phases.Running:
                return actualPhase = new RunningPhase(this);
            default:
                return actualPhase = new NormalPhase(this);
        }
    }

    public void ClearAbility()
    {
        actualAbility = null;
        abilityImage.ClearImage();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(0, bottomDieAnchor, 0), 0.5f);
        Gizmos.DrawSphere(new Vector3(0, topDieAnchor, 0), 0.5f);
    }

    public void ActivateAbility()
    {
        if (actualAbility == null) return;
        actualAbility.Activate();
        activeAbilities.Add(actualAbility);
        actualAbility = null;
        abilityImage.ClearImage();
    } 

    private void UpdateAbilities()
    {
        int i = 0;
        while(i<10) {
            if (i >= activeAbilities.Count) break;
            SuperAbility x = activeAbilities[i];
            x.Update();
            if (x.IsFinished()) activeAbilities.Remove(x);
            i++;
            
        }
    }

    public void SetInput(bool active)
    {
        activeInput = active;
    }
}
