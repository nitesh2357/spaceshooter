using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class invoke : MonoBehaviour {

    private List<Icommand> _commands = new List<Icommand>();

    public void StoreAndExecute(Icommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}
