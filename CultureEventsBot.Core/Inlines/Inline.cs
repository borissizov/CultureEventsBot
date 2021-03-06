using System.Threading.Tasks;
using CultureEventsBot.Persistance;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CultureEventsBot.Core.Inlines
{
	public abstract class	Inline
    {
        public abstract string	Name { get; }
		
		public abstract Task	ExecuteAsync(CallbackQuery callbackQuery, TelegramBotClient client, DataContext context);
		public virtual bool	Contains(CallbackQuery callbackQuery)
		{
			var	res = callbackQuery != null && callbackQuery.Data != null;
			var	splitName = Name.Split(",");

			if (res)
			{
				foreach (var name in splitName)
				{
					res = callbackQuery.Data.Contains(name);
					if (res) break ;
				}
			}
			return (res);
		}
    }
}