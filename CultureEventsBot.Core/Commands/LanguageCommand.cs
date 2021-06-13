using System.Threading.Tasks;
using CultureEventsBot.Core.Core;
using CultureEventsBot.Domain.Enums;
using CultureEventsBot.Persistance;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CultureEventsBot.Core.Commands
{
	public class LanguageCommand : Command
	{
		public override string Name => @"/language";

		public override async Task Execute(Message message, TelegramBotClient client, DataContext context)
		{
			await Send.SendInlineKeyboard(message.Chat.Id, @"/language", client);
			await Task.CompletedTask;
		}
	}
}