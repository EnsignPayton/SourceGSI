﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SourceGSI.UI.Core.Entities;

namespace SourceGSI.UI.Core
{
    public sealed class GameStateServer : IGameStateServer, IDisposable
    {
        private readonly HttpListener _httpListener = new HttpListener();
        private bool _isDisposed;

        public event EventHandler<GameStateEventArgs> ReceivedGameState;

        public int Port { get; set; }

        public bool IsRunning { get; private set; }

        public string RawJson { get; private set; }

        public GameState GameState { get; private set; }

        public void Start()
        {
            if (IsRunning) return;

            try
            {
                if (_httpListener.Prefixes.Any())
                    _httpListener.Prefixes.Clear();
                _httpListener.Prefixes.Add($"http://localhost:{Port}/");
                _httpListener.Start();
            }
            catch (HttpListenerException)
            {
                // TODO: Log exception
            }

            Task.Run(Run);
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        private async Task Run()
        {
            while (IsRunning)
            {
                try
                {
                    var context = await _httpListener.GetContextAsync();
                    var request = context.Request;
                    string data;

                    using (var inputStream = request.InputStream)
                    using (var streamReader = new StreamReader(inputStream))
                    {
                        data = await streamReader.ReadToEndAsync();
                    }

                    using (var response = context.Response)
                    {
                        response.StatusCode = (int) HttpStatusCode.OK;
                        response.StatusDescription = "OK";
                        response.Close();
                    }

                    RawJson = data;
                    GameState = JsonConvert.DeserializeObject<GameState>(data);

                    SendGameState();
                }
                catch (ObjectDisposedException)
                {
                    // TODO: Log exception
                }
            }

            _httpListener.Stop();
        }

        private void SendGameState()
        {
            ReceivedGameState?.Invoke(this, new GameStateEventArgs
            {
                GameState = GameState,
                RawJson = RawJson
            });
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _isDisposed = true;

            _httpListener?.Close();
        }
    }
}
