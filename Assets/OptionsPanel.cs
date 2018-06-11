using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour {

    public Player player;
    public Toggle colorToggle;
    public Toggle sizeToggle;

    public Action[] colorActions;
    public Action[] sizeActions;

    public void OnToggle()
    {
        List<Action> actions = new List<Action>();
        if (colorToggle.isOn)
            foreach (Action a in colorActions)
                actions.Add(a);
        if (sizeToggle.isOn)
            foreach (Action a in sizeActions)
                actions.Add(a);
        player.SetActions(actions);
    }

}
