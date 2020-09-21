using UnityEngine;

namespace Kultie
{
    public class Spring
    {
        private float x;
        private float k;
        private float d;
        private float target;
        private float v = 0;

        public Spring(float origin = 0, float stiffness = 100, float dampening = 10)
        {
            x = origin;
            k = stiffness;
            d = dampening;
            target = x;
            v = 0;
        }

        public void Update(float dt)
        {
            OnUpdate(dt);
        }

        public void Update()
        {
            float dt = Time.deltaTime;
            OnUpdate(dt);
        }

        private void OnUpdate(float dt)
        {
            float a = -k * (x - target) - d * v;
            v = v + a * dt;
            x = x + v * dt;
        }

        public void Pull(float force, float stiffness = 100, float dampening = 10)
        {
            k = stiffness;
            d = dampening;
            x = x + force;
        }

        public float GetValue()
        {
            return x;
        }
    }
}
