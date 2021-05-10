using MiniBot.Activity;
using LogCustom;

namespace MiniBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Info("Start debug.");
            AssistantBot.Hello();

        startloop:
            AssistantBot assistant = new AssistantBot();
            int answer = assistant.ShowMenuToUser();

            switch (answer)
            {
                case 1:
                    assistant.ChoosePizza();
                    break;
                case 2:
                    assistant.ChooseDrink();
                    break;
            }

            if (assistant.ShowBasketOrMenu())
            {
                goto startloop;
            }

            assistant.ActionWithBasket();

            if (assistant.GetNewOrder())
            {
                assistant = null;
                goto startloop;
            }
            else
            {
                assistant = null;
            }

            Logger.Info("Solution completed successfully.");
        }
    }
}
