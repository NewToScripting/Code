using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire.Interfaces
{
    public interface IPlayable
    {
        void Play();
        void Stop();
        bool IsPlaying();
    }
}
