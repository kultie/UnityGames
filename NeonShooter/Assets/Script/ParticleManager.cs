using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager<T>
{
    public class customParticle
    {
        public SpriteRenderer sp;
        public Vector2 Position;
        public float Orientation;

        public Vector2 Scale = Vector2.one;

        public Color Color;
        public float Duration;
        public float PercentLife = 1f;
        public T State;
    }
    private class CircularParticleArray
    {
        private int start;
        public int Start
        {
            get { return start; }
            set { start = value % list.Length; }
        }

        public int Count { get; set; }
        public int Capacity { get { return list.Length; } }
        private customParticle[] list;

        public CircularParticleArray(int capacity)
        {
            list = new customParticle[capacity];
        }

        public customParticle this[int i]
        {
            get { return list[(start + i) % list.Length]; }
            set { list[(start + i) % list.Length] = value; }
        }
    }
}
