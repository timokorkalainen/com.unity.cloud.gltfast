﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLTFast {
    
    public class TimeBudgetPerFrameDeferAgent : MonoBehaviour, IDeferAgent
    {
        float lastTime;
        float timeBudget;

        // Start is called before the first frame update
        public TimeBudgetPerFrameDeferAgent( float frameBudget = 0.5f )
        {
            float targetFrameRate = Application.targetFrameRate;
            if(targetFrameRate<0) targetFrameRate = 30;
            timeBudget = frameBudget/targetFrameRate;
            Reset();
        }

        void Update() {
            Reset();
        }

        void Reset()
        {
            lastTime = Time.realtimeSinceStartup;
        }

        public bool ShouldDefer() {
            float now = Time.realtimeSinceStartup;
            if( now-lastTime > timeBudget ) {
                lastTime = now;
                return true;
            }
            return false;
        }
    }
}