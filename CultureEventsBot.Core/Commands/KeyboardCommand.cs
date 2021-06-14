using System.Threading.Tasks;
using CultureEventsBot.Core.Core;
using CultureEventsBot.Core.Dialog;
using CultureEventsBot.Persistance;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace CultureEventsBot.Core.Commands
{
	public class	KeyboardCommand : Command
	{
		public override string	Name => "/keyboard";

		public override async Task	ExecuteAsync(Message message, TelegramBotClient client, DataContext context)
		{
			var	user = await context.Users.FirstOrDefaultAsync(u => u.ChatId == message.Chat.Id);
			
			await Send.SendMessageAsync(message.Chat.Id, LanguageHandler.ChooseLanguage(user.Language, "Keyboard is available", "Клавиатура включена"), client,
				replyMarkup: new ReplyKeyboardMarkup(Keyboard.GetKeyboardMatrix(
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Menu", "Меню"), LanguageHandler.ChooseLanguage(user.Language, "Weather", "Погода")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Show event", "Следущее событие"), LanguageHandler.ChooseLanguage(user.Language, "Show events 5", "Ближайшие 5 событий")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Show film", "Следущий фильм"), LanguageHandler.ChooseLanguage(user.Language, "Show films 5", "Ближайшие 5 фильмов")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Show place", "Следуйщее место"), LanguageHandler.ChooseLanguage(user.Language, "Show places 5", "Ближайшие 5 мест")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Favourites", "Избранное")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Search events by categories", "Искать события по категориям")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Search films by genres", "Искать фильмы по жанрам")),
					Keyboard.GetKeyboardLine(LanguageHandler.ChooseLanguage(user.Language, "Search places by categories", "Искать места по категориям"))
				))
			);
		}
	}
}