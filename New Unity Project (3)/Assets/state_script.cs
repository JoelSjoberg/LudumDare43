﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_script : MonoBehaviour {
    [SerializeField]private bool dead, active_player, launched;

    public bool getDead()           { return dead; }
    public bool getActivePlayer()   { return active_player; }
    public bool getLaunched()       { return launched; }

    public void setDead(bool d)         { dead = d; }
    public void setActivePlayer(bool a) { active_player = a; }
    public void setLaunched(bool l)     { launched = l; }

    public ballType type;
}

public enum ballType { bounce, boost, secondWind, shrink, christmas};
