// Install the C# / .NET helper library from twilio.com/docs/csharp/install

using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Video.V1;
using static Twilio.Rest.Video.V1.CompositionResource;

class Program
{
    static void Main(string[] args)
    {
        // Find your API Key SID and Secret at twilio.com/console
        const string apiKeySid = "SKXXXX";
        const string apiKeySecret = "your_api_key_secret";

        TwilioClient.Init(apiKeySid, apiKeySecret);

        var layout = new
        {
            main = new
            {
                z_pos = 1,
                video_sources = new string[]{"screen-presentation"}
            },
            pip = new {
                z_pos = 2,
                x_pos = 1000,
                y_pos = 30,
                width = 240,
                height = 180,
                video_sources = new string[]{"MTBBBB"}
            }
        };

        var composition = CompositionResource.Create(
          roomSid: "RMXXXX",
          audioSources: new List<string>{"MTAAAA", "soundtrack"},
          videoLayout: layout,
          statusCallback: new Uri('http://my.server.org/callbacks'),
          resolution: "1280x720",
          format: FormatEnum.Mp4
        );

        Console.WriteLine($"Created composition with SID: {composition.Sid}");
    }
}
