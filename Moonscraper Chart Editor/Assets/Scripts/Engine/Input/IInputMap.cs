﻿using System.Collections;
using System.Collections.Generic;

namespace MSE
{
    namespace Input
    {
        public interface IInputMap
        {
            string GetInputStr();
            bool HasConflict(IInputMap other);
        }
    }
}
