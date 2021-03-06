﻿using AsyncClientServer.Client;
using AsyncClientServer.Server;

namespace AsyncClientServer.StateObject.StateObjectState
{
	public class MessageHasBeenReceivedState: StateObjectState
	{
		public MessageHasBeenReceivedState(IStateObject state) : base(state,null)
		{
		}

		public MessageHasBeenReceivedState(IStateObject state, IAsyncClient client) : base(state, client)
		{
		}

		/// <summary>
		/// Invokes MessageReceived when a message has been fully received.
		/// </summary>
		/// <param name="receive"></param>
		public override void Receive(int receive)
		{
			if (Client == null)
			{
				AsyncSocketListener.Instance.InvokeMessageReceived(State.Id,State.Header,State.Text);
				return;
			}

			Client.InvokeMessage(State.Header, State.Text);

		}
	}
}
