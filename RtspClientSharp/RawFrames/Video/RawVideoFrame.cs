using System;

namespace RtspClientSharp.RawFrames.Video
{
    public abstract class RawVideoFrame : RawFrame
    {
        protected RawVideoFrame(DateTime timestamp, ArraySegment<byte> frameSegment)
            : base(FrameType.Video, timestamp, frameSegment)
        {
        }
    }
}