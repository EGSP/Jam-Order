﻿using System;

namespace Game.Scenes.Exceptions
{
    public class SceneParamsException<TParamsType> : Exception
    {
        public SceneParamsException() 
            : base($"Expected scene params of type {typeof(TParamsType).Name}")
        {
            
        }

        public SceneParamsException(SceneParams @params) 
            : base($"Expected scene params of type {typeof(TParamsType).Name}. " +
                   $"Current is {@params.GetType().Name}")
        {
            
        }
    }
}