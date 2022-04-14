using RtspClientSharp.RawFrames;
using System;

namespace RtspClientSharp.MediaParsers
{
	class RawPayloadParser : IMediaPayloadParser
	{
		public Action<RawFrame> FrameGenerated { get; set; }

		private byte[] _buffer = new byte[1024];
		private int _bufferUsed = 0;


		public void Parse(TimeSpan timeOffset, ArraySegment<byte> byteSegment, bool markerBit)
		{
			if (_bufferUsed + byteSegment.Count > _buffer.Length)
				Array.Resize(ref _buffer, _buffer.Length * 2);

			Array.Copy(byteSegment.Array, byteSegment.Offset, _buffer, _bufferUsed, byteSegment.Count);
			_bufferUsed += byteSegment.Count;

			if (markerBit)
			{
				FrameGenerated.Invoke(new RawFrame(FrameType.Raw, DateTime.UtcNow, new ArraySegment<byte>(_buffer, 0, _bufferUsed)));

				ResetState();
			}
		}

		public void ResetState()
		{
			_bufferUsed = 0;
		}
	}
}
