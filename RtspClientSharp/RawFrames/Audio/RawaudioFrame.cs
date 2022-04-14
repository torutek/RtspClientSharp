using System;

namespace RtspClientSharp.RawFrames.Audio
{
    public abstract class RawAudioFrame : RawFrame
    {
        protected RawAudioFrame(DateTime timestamp, ArraySegment<byte> frameSegment)
            : base(FrameType.Audio, timestamp, frameSegment)
        {
        }
    }
}