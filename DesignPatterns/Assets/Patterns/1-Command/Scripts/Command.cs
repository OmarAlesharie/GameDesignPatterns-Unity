using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim, bool forward);
}

public class RunFast : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isRunFast");
        }
        else
            anim.SetTrigger("isRunFastR");
    }
}

public class BackFlip : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isBackFlip");
        }
        else
            anim.SetTrigger("isBackFlipR");
    }
}

public class MagicSpell : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isMagicSpell");
        }
        else
            anim.SetTrigger("isMagicSpellR");
    }
}

public class UppercutJab : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
        {
            anim.SetTrigger("isUppercutJab");
        }
        else
            anim.SetTrigger("isUppercutJabR");
    }
}

