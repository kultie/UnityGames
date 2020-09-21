
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
namespace Kultie.TimerSystem
{
    public class Timer
    {
        Dictionary<string, TimerElement> dicTimer;

        public bool isRunning
        {
            get
            {
                return dicTimer.Count > 0;
            }
        }
        public Timer()
        {
            dicTimer = new Dictionary<string, TimerElement>();
        }

        public void After(float delay, Action action, bool repeatable = false, string tag = "")
        {
            TimerElement timer = new TimerElement(delay, action, repeatable);
            if (string.IsNullOrEmpty(tag)) tag = Guid.NewGuid().ToString();
            if (dicTimer.ContainsKey(tag))
            {
                dicTimer[tag] = timer;
            }
            else
            {
                dicTimer.Add(tag, timer);
            }
        }

        public void After(float delay, Action action, int repeatTime, string tag = "")
        {
            TimerElement timer = new TimerElement(delay, action, repeatTime);
            if (string.IsNullOrEmpty(tag)) tag = DateTime.Now.ToString();
            if (dicTimer.ContainsKey(tag))
            {
                dicTimer[tag] = timer;
            }
            else
            {
                dicTimer.Add(tag, timer);
            }
        }

        public void RemoveTag(string tag)
        {
            dicTimer.Remove(tag);
        }

        public void Update(float dt)
        {
            var list = new Dictionary<string, TimerElement>(dicTimer);
            foreach (KeyValuePair<string, TimerElement> val in list)
            {
                TimerElement timer = val.Value;
                timer.currentTime = timer.currentTime + dt;
                if (timer.currentTime > timer.delay)
                {
                    if (timer.action != null)
                    {
                        timer.action?.Invoke();
                    }
                    if (timer.repeatable)
                    {
                        if (timer.repeatTime > 0)
                        {
                            timer.repeatTime = timer.repeatTime - 1;
                            if (timer.repeatTime > 0)
                            {
                                timer.currentTime = 0;
                            }
                            else
                            {
                                timer.repeatable = false;
                                dicTimer.Remove(val.Key);
                            }
                        }
                        else
                        {
                            timer.currentTime = 0;
                        }
                    }
                    else
                    {
                        dicTimer.Remove(val.Key);
                    }
                }
            }
        }
    }

    class TimerElement
    {
        public float delay;
        public Action action;
        public bool repeatable;
        public int repeatTime;
        public float currentTime;

        public TimerElement(float _delay, Action _action, bool _repeatable)
        {
            delay = _delay;
            action = _action;
            repeatable = _repeatable;
            currentTime = 0;
        }

        public TimerElement(float _delay, Action _action, int _repeatTime)
        {
            delay = _delay;
            action = _action;
            repeatTime = _repeatTime;
            currentTime = 0;
            if (repeatTime > 0)
            {
                repeatable = true;
            }
        }
    }
}
