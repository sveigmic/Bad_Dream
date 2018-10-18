using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SupportController : MonoBehaviour {

    [System.Serializable]
    public struct UIPointers
    {
        public RectTransform normalUI;
        public RectTransform runUI;
        public RectTransform abilityBtn;
        public RectTransform ui;
        public Text dialog;
        public Text smallDialog;

        public Dictionary<string, GameObject[]> resources;
    }

    [System.Serializable]
    public struct QuestResources
    {
        public string name;
        public GameObject[] objects;
    }

    public QuestResources[] questObjects;



    public VirtualJoystick joystick;
    public TouchManager touchManager;
    public PhaseController player;

    public UIPointers uiPointers;

    Quest[] quests;

    private int actQuest = -1;

    void Start () {
        joystick.gameObject.SetActive(false);
        uiPointers.abilityBtn.gameObject.SetActive(false);
        Dictionary<string, GameObject[]> resources = new Dictionary<string, GameObject[]>();
        foreach (QuestResources x in questObjects)
        {
            resources.Add(x.name, x.objects);
        }
        uiPointers.resources = resources;
        quests = new Quest[2];
        quests[0] = new FirstQuest(player, uiPointers);
        quests[1] = new SimpleMoveQuest(player, uiPointers);
        NextQuest();
	}
	
	void Update () {
        if(actQuest >= quests.Length)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        quests[actQuest].Update();
        if (quests[actQuest].isComplete()) NextQuest();
	}

    private void NextQuest()
    {
        actQuest++;
        if (actQuest >= quests.Length)
        {
            return;
        }
        quests[actQuest].Start();
    }
}
