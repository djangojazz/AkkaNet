using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");

            Receive<PlayMovieMessage>(message => HandlePlayMovie(message));
        }

        private void HandlePlayMovie(PlayMovieMessage message)
        {
            ColorConsole.WriteLineYellow($"PlayMovieMessage '{message.MovieTitle}' for user {message.UserId}");
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("PlayActor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("PlayActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("Playback PreStart because " + reason);

            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("Playback PostStart because " + reason);

            base.PostRestart(reason);
        }
    }
}
