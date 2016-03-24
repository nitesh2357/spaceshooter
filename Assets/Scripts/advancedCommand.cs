using UnityEngine;
using System.Collections;

public class advancedCommand : Icommand {

    private level _level;

    public advancedCommand(level level)
    {
        _level = level;
    }

    public void Execute()
    {
        _level.advanced();
    }
}
