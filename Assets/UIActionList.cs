using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionList : MonoBehaviour {

    public List<Action> actions = new List<Action>();
    public UIAction uiPrefab;

    Dictionary<Action, UIAction> uiActions = new Dictionary<Action, UIAction>();

	// Use this for initialization
	void Start () {
        uiPrefab.gameObject.SetActive(false);
        UpdateActions();
	}
	
	void UpdateActions()
    {
        // go through the list and remove any actions no longer in our data
        List<Action> deathRow = new List<Action>();
        foreach (KeyValuePair<Action, UIAction> pair in uiActions)
        {
            if (actions.Contains(pair.Key) == false)
            {
                Destroy(pair.Value.gameObject);
            }
        }
        // remove them from the list
        foreach (Action a in deathRow)
            uiActions.Remove(a);


        // go through our actions and create instances from the prefab
        foreach (Action a in actions)
        {
            if (uiActions.ContainsKey(a) == false)
            {
                GameObject go = Instantiate(uiPrefab.gameObject, transform);
                go.SetActive(true);
                uiActions[a] = go.GetComponent<UIAction>();
                uiActions[a].SetAction(a);
            }
        }
	}
}
