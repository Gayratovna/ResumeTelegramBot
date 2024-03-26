using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.IO;

namespace resumeTelegramBot
{

    class Program
    {
        const string startCommand = "/start";
        const string aboutMeCommand = "About me";
        const string contactCommand = "Contact";
        const string skilsCommand = "Skils";
        const string languageCommand = "Language";
        const string addresCommand = "Addres";
        const string phoneCommand = "Phone";
        const string censelCommand = "Censel";

        static void Main(string[] args)
        {
            string token = "6944666419:AAHj0ol7MOizQbMZWn5qWzwuYTKAXKqjTn8";
            var telegrambot = new TelegramBotClient(token);

            telegrambot.StartReceiving(HandleUpdate, HandleError);

            Console.ReadLine();
        }


        private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message?.Type is MessageType.Text)
            {
                if (update.Message.Text is startCommand)
                {
                    var murkup = MenuMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Welcome to, my resume",
                        replyMarkup: murkup
                        );
                }
                if (update.Message.Text is aboutMeCommand)
                {
                    string path = @"../../../Images/child.png";
                    using (var photo = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        await client.SendPhotoAsync(
                            chatId: update.Message.Chat.Id,
                           photo: InputFile.FromStream(photo),
                           caption: "My name is John"
                            );
                    }
                }
                if (update.Message.Text is contactCommand)
                {
                    var murkup = ContactMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: $"Learn about me",
                        replyMarkup: murkup
                        );
                }
                if (update.Message.Text is skilsCommand)
                {
                    var murkup = MenuMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "John enjoys horse riding and studying languages",
                        replyMarkup: murkup);
                }
                if (update.Message.Text is languageCommand) 
                {
                    var murkup = MenuMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "John speaks English, Russian and German",
                        replyMarkup: murkup);
                }
                if (update.Message.Text is addresCommand)
                {
                    var murkup = MenuMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "John lives on Albany Street in New York City, USA",
                        replyMarkup: murkup);
                }
                if (update.Message.Text is phoneCommand)
                {
                    var murkup = MenuMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "My phone number: +13329006170",
                        replyMarkup: murkup);

                }

                if (update.Message.Text is censelCommand)
                {
                    var mrkup = MenuMurkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Censel! Menu 😊",
                        replyMarkup: mrkup
                        );
                }
            }

        }

        private static ReplyKeyboardMarkup ContactMurkup()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[]{new KeyboardButton("Skils"), new KeyboardButton("Language") },
                new KeyboardButton[]{new KeyboardButton("Address"), new KeyboardButton("Phone")},
                new KeyboardButton[]{new KeyboardButton("Censel")}


            });
        }

        private static ReplyKeyboardMarkup MenuMurkup()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[] { new KeyboardButton("About me"), new KeyboardButton("Contact") }
            });
            {
            }
        }

        private static async Task HandleError(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            await client.SendTextMessageAsync(
               chatId: 6944666419,
               text: $"{exception.Message}"
               );
        }
    }
}