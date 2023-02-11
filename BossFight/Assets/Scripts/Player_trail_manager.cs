using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_trail_manager : MonoBehaviour
{
    public TrailRenderer swordTrail;

    private void trail_start()
    {
        swordTrail.enabled = true;
    }
    private void trail_end()
    {
        swordTrail.enabled = false;
    }
    private void trail_start_2()
    {
        swordTrail.enabled = true;
    }
    private void trail_end_2()
    {
        swordTrail.enabled = false;
    }
}
