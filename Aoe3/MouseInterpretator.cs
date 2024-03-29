﻿using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace Aoe3
{

    public static class MouseInterpretator
    {
        static MouseState lastState;
        static bool timeElapsed = true;
        static Timer timer;

        public static MouseButton bt = MouseButton.None;
        public static void Start()
        {
            timer = new Timer(50);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeElapsed = true;
        }
        public static void ResetInter()
        {
            lastState = new MouseState();
        }
        public static bool GetPressedAllTime(MouseButton mButton)
        {
            bool yes = true;
            MouseState mouseState = Mouse.GetState();

            switch (mButton)
            {
                case MouseButton.Left:
                    yes = yes && mouseState.LeftButton == ButtonState.Pressed;
                    break;
                case MouseButton.Right:
                    yes = yes && mouseState.RightButton == ButtonState.Pressed;
                    break;
                case MouseButton.Middle:
                    yes = yes && mouseState.MiddleButton == ButtonState.Pressed;
                    break;
            }
            lastState = mouseState;
            return yes;
        }
        public static bool GetPressed(MouseButton mButton)
        {
            bool yes = false;
            MouseState mouseState = Mouse.GetState();
            if (lastState != mouseState || timeElapsed)
            {
                yes = true;
            }

            switch (mButton)
            {
                case MouseButton.Left:
                    yes = yes && mouseState.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Right:
                    yes = yes && mouseState.RightButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released;
                    break;
                case MouseButton.Middle:
                    yes = yes && mouseState.MiddleButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released;
                    break;
            }
            lastState = mouseState;
            return yes;
        }
        public static void GetPressed()
        {
            bool yes = false;
            MouseState mouseState = Mouse.GetState();
            if (lastState != mouseState || timeElapsed)
            {
                yes = true;
            }
            bt = MouseButton.None;
            if (mouseState.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released)
            {
                bt = MouseButton.Left;
            }
            if (mouseState.RightButton == ButtonState.Pressed && lastState.RightButton == ButtonState.Released)
            {
                bt = MouseButton.Right;
            }
            if (mouseState.MiddleButton == ButtonState.Pressed && lastState.MiddleButton == ButtonState.Released)
            {
                bt = MouseButton.Middle;
            }
            lastState = mouseState;
            if (!yes)
            {
                bt = MouseButton.None;
            }
        }
    }
}
