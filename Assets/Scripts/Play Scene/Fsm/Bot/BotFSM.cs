﻿using UnityEngine;
using System.Collections;

namespace devdayo.Fsm.Bot
{
    [RequireComponent(typeof(Tween))]
    public class BotFSM : StateMachineBehaviour
    {
        internal Rigidbody2D rigidbody;
        internal Animator animator;

        public Collider2D boxCollider;
        public Collider2D polyCollider;

        public Tween tween;

        public float moveSpeed = 3;
        public float jumpPower = 6;

        public bool immortal = false;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            /*
            boxCollider = GetComponent<BoxCollider2D>();
            polyCollider = GetComponent<PolygonCollider2D>();

            tween = GetComponent<Tween>();
            */
        }

        void Start()
        {
            AddTransition(Transition.OnMove, typeof(State.OnMove));
            AddTransition(Transition.OnFlop, typeof(State.OnFlop));
            AddTransition(Transition.OnDied, typeof(State.OnDied));

            DoTransition(Transition.OnMove);
        }
    }

    public static class Transition
    {
        public const int OnMove = 1;
        public const int OnFlop = 2;
        public const int OnDied = 3;
    }
}