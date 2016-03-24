using UnityEngine;
using System.Collections;

public class menuCommand : Icommand {

    private level _level;

    public menuCommand(level level)
    {
        _level = level;
    }

    public void Execute()
    {
        _level.menu();
    }
}
