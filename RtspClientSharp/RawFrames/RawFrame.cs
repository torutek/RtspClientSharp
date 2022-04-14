using System;

namespace RtspClientSharp.RawFrames
{
    public class RawFrame
    {
        public DateTime Timestamp { get; }
        public ArraySegment<byte> FrameSegment { get; }
        public FrameType Type { get; }

        public RawFrame(FrameType type, DateTime timestamp, ArraySegment<byte> frameSegment)
        {
            Type = type;
            Timestamp = timestamp;
            FrameSegment = frameSegment;
        }
    }
}