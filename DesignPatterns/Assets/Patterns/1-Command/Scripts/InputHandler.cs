using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    Animator anim;
    Command KeyQ, KeyW, KeyE, upArrow;
    List<Command> oldCommands = new List<Command>();

    Coroutine replayCoroutine;
    bool shouldStartReply;
    bool isReplaying;

    // Start is called before the first frame update
    void Start()
    {
        KeyQ = new BackFlip();
        KeyW = new MagicSpell();
        KeyE = new UppercutJab();
        upArrow = new RunFast();
        anim = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReplaying)
        {
            HandleInpput();
        }
        StartReplay();
    }

    void HandleInpput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            KeyQ.Execute(anim, true);
            oldCommands.Add(KeyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            KeyW.Execute(anim, true);
            oldCommands.Add(KeyW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            KeyE.Execute(anim, true);
            oldCommands.Add(KeyE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute(anim, true);
            oldCommands.Add(upArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldStartReply = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand()
    {
        if (oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(anim, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }

    void StartReplay()
    {
        if (shouldStartReply && oldCommands.Count > 0)
        {
            shouldStartReply = false;
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands()
    {
        isReplaying = true;

        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(anim, true);
            yield return new WaitForSeconds(1f);
        }

        isReplaying = false;
    }
}
