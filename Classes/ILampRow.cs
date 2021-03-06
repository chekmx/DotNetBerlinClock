﻿using System.Collections.Generic;

namespace BerlinClock
{
    public interface ILampRow
    {
        IEnumerable<Lamp> Lamps { get; }

        void SwitchOnLamps(Time time);
        string ToString();
    }
}