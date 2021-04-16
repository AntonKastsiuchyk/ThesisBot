using System;
using MiniBot.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using MiniBot.Activity;
using MiniBot.ProductRepositories;
using LogCustom;
using MiniBot.Repositories.BasketRepository;

namespace MiniBot
{
    class Program
    {
        static void Main(string[] args)
        {
            AssistantBot.Hello();
            AssistantBot.ShowMenuForUser();
        }
    }
}
