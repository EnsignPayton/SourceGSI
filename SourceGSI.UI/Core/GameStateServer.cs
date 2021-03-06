﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Caliburn.Micro;
using Newtonsoft.Json;
using SourceGSI.UI.Core.Entities;
using SourceGSI.UI.Core.Events;

namespace SourceGSI.UI.Core
{
    public sealed class GameStateServer : IGameStateServer, IDisposable
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly HttpListener _httpListener = new HttpListener();
        private bool _isDisposed;

        public int Port { get; set; }

        public bool IsRunning { get; private set; }

        public GameState GameState { get; private set; }

        public GameStateServer(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

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

                    GameState = JsonConvert.DeserializeObject<GameState>(data);

                    _eventAggregator.PublishOnUIThread(new GameStateReceived(GameState));
                }
                catch (ObjectDisposedException)
                {
                    // TODO: Log exception
                }
            }

            _httpListener.Stop();
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _isDisposed = true;

            _httpListener?.Close();
        }
    }
}
