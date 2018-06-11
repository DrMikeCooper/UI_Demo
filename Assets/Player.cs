using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

    public List<Action> actions;

    [System.Serializable]
    public class PlayerEvent : UnityEvent<Player>
    { }

    public PlayerEvent onActionsChanged;

	// Use this for initialization
	void Start () {
        onActionsChanged.Invoke(this);
	}

    public void SetActions(List<Action> acs)
    {
        actions = acs;
        onActionsChanged.Invoke(this);
    }

}
