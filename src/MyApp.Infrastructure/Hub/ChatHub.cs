using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MyApp.Infrastructure.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        // TODO: Add atuthorization to get user information on connection
        // TODO: manage users inside database
        private static Dictionary<string, string> Users = new();

        public async Task SendMessage(string user, string message)
        {
            var userId = Context.ConnectionId;
            Users[userId] = user;
            await Clients.Others.SendAsync("ReceiveMessage", new { User = user, Message = message });
        }

        public override Task OnConnectedAsync()
        {
            var user = Context.ConnectionId;
            Users.Add(user, "");
            Clients.Others.SendAsync("Connected", $"New user connected - {user}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = Context.ConnectionId;
            var userName = Users[user];
            Users.Remove(user);
            Clients.Others.SendAsync("Disconnected", $"User disconnected - {userName}");
            return base.OnConnectedAsync();
        }

        // character movement test
        public Task SendPosition(Vector2 position)
        {
            var user = Context.ConnectionId;

            return Clients.Others.SendAsync("NewPosition", new Player(user, position));
        }

        public Task SendRotation(Vector3 rotation)
        {
            var user = Context.ConnectionId;

            return Clients.Others.SendAsync("NewRotation", rotation);
        }

        public class Player
        {
            public string Id { get; set; }
            public Vector2 Position { get; set; }

            public Player(string id, Vector2 position)
            {
                Id = id;
                Position = position;
            }
        }

        public class Vector2
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        public class Vector3
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
        }
    }
}