using System.Threading.Tasks;
using CultureEventsBot.Core.Core;
using CultureEventsBot.Persistance;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CultureEventsBot.Core.Commands
{
	public class LanguageCommand : Command
	{
		public override string Name => @"/language";

		public override async Task Execute(Message message, TelegramBotClient client, DataContext context)
		{
			var	user = await context.Users.FirstOrDefaultAsync(u => u.ChatId == message.Chat.Id);
			
			await Send.SendInlineKeyboard(message.Chat.Id, LanguageHandler.ChooseLanguage(user.Language, "Choose language:", "Выберите язык:"), client);
		}
	}
}