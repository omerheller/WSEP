﻿using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Communication
{
    public class Server
    {
        private static Lazy<Server> LazyInstance = new Lazy<Server>(() => new Server(), true);
        private HubConnection hubConnection;
        private Server()
        {

        }
        public static Server Instance
        {
            get { return LazyInstance.Value; }
        }

        public bool connect()
        {
            try
            {
                hubConnection = new HubConnection("http://52.29.58.18:80/");
                IHubProxy authHubProxy = hubConnection.CreateHubProxy("AuthHub"); 
                IHubProxy gameCenterProxy = hubConnection.CreateHubProxy("GameCenterHub");
                IHubProxy gameProxy = hubConnection.CreateHubProxy("GameHub");

                AuthFunctions authFunction = AuthFunctions.Instance;
                authFunction.AuthHubProxy = authHubProxy;
                authFunction.initOnFunctions();

                GameCenterFunctions gameCenterFunction = GameCenterFunctions.Instance;
                gameCenterFunction.GameCenterHubProxy = gameCenterProxy;
                gameCenterFunction.initOnFunctions();

                GameFunctions gameFunction = GameFunctions.Instance;
                gameFunction.GameHubProxy = gameProxy;
                gameFunction.initOnFunctions();

                hubConnection.Start().Wait();

            }
            catch
            {
                return false;
            }

            return true;

        }

        public bool disconnect()
        {
            try
            {
                hubConnection.Stop();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


}
