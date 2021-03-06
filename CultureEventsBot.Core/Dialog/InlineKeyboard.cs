using System;
using System.Collections.Generic;
using System.Linq;
using CultureEventsBot.Core.Core;
using CultureEventsBot.Domain.Entities;
using Telegram.Bot.Types.ReplyMarkups;

namespace CultureEventsBot.Core.Dialog
{
	public static class	InlineKeyboard
  {
    public static IEnumerable<IEnumerable<InlineKeyboardButton>>	GetInlineKeyboard(int columns, params string[] keywords)
		{
			var inlineKeyboard = new List<IEnumerable<InlineKeyboardButton>>();
			var inlineKeyboardButtons = new List<InlineKeyboardButton>();

			foreach (var keyword in keywords)
			{
				if (inlineKeyboardButtons.FirstOrDefault(b => b.Text == keyword) == null)
				{
					var btn = new InlineKeyboardButton
					{
						Text = keyword,
						CallbackData = keyword
					};

					inlineKeyboardButtons.Add(btn);
				}
			}
			for (int i = 0; i < inlineKeyboardButtons.Count; i += columns)
			{
				var tempKeyboardButtons = new List<InlineKeyboardButton>();

				for (int j = 0; j < columns && i + j < inlineKeyboardButtons.Count; ++j)
					tempKeyboardButtons.Add(inlineKeyboardButtons[i + j]);
				inlineKeyboard.Add(tempKeyboardButtons);
			}
			return (inlineKeyboard);
		}
    public static IEnumerable<IEnumerable<InlineKeyboardButton>>	GetInlineMatrix(int columns, params InlineKeyboardButton[] inlineKeyboardButtons)
		{
			var inlineKeyboard = new List<IEnumerable<InlineKeyboardButton>>();

			for (int i = 0; i < inlineKeyboardButtons.Length; i += columns)
			{
				var tempKeyboardButtons = new List<InlineKeyboardButton>();

				for (int j = 0; j < columns && i + j < inlineKeyboardButtons.Length; ++j)
					tempKeyboardButtons.Add(inlineKeyboardButtons[i + j]);
				inlineKeyboard.Add(tempKeyboardButtons);
			}
			return (inlineKeyboard);
		}
    public static IEnumerable<InlineKeyboardButton>	GetInlineKeyboardLine(Dictionary<string, string> words)
		{
			var res = new List<InlineKeyboardButton>();

			foreach (var word in words)
				if (res.FirstOrDefault(b => b.Text == word.Key) == null)
					res.Add(GetInlineKeyboardButton(word.Value, word.Key));
			return (res);
		}
    public static InlineKeyboardButton	GetInlineKeyboardButton(string value, string key)
		{
			var res = new InlineKeyboardButton
			{
				Text = value,
				CallbackData = key
			};

			return (res);
		}
    public static IEnumerable<IEnumerable<InlineKeyboardButton>>	GetDateInlineKeyboard(User user)
		{
			var	months = new []
			{
				LanguageHandler.ChooseLanguage(user.Language, "January", "????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "February", "??????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "March", "????????"),
				LanguageHandler.ChooseLanguage(user.Language, "April", "????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "May", "??????"),
				LanguageHandler.ChooseLanguage(user.Language, "June", "????????"),
				LanguageHandler.ChooseLanguage(user.Language, "July", "????????"),
				LanguageHandler.ChooseLanguage(user.Language, "August", "????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "Septembery", "????????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "October", "??????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "November", "????????????"),
				LanguageHandler.ChooseLanguage(user.Language, "December", "??????????????")
			};
			var	currentDate = user.FilterDate;
			var	beginMonthDay = new DateTime(currentDate.Year, currentDate.Month, 1);
			var	endMonthDay = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
			var inlineKeyboard = new List<IEnumerable<InlineKeyboardButton>>();
			var inlineKeyboardButtons = new List<InlineKeyboardButton>();
			
			inlineKeyboard.Add(InlineKeyboard.GetInlineKeyboardLine(new Dictionary<string, string>
			{
				{ "prev-date", "<<" },
				{ currentDate.Year.ToString(), currentDate.Year.ToString() },
				{ "next-date", ">>" }
			}));
			inlineKeyboard.Add(InlineKeyboard.GetInlineKeyboardLine(new Dictionary<string, string>
			{
				{ "prev-day", "<" },
				{ months[currentDate.Month - 1], months[currentDate.Month - 1] },
				{ "next-day", ">" }
			}));
			inlineKeyboard.Add(InlineKeyboard.GetInlineKeyboardLine(new Dictionary<string, string>
			{
				{ LanguageHandler.ChooseLanguage(user.Language, "Monday", "??????????????????????"), LanguageHandler.ChooseLanguage(user.Language, "Mon", "??????") },
				{ LanguageHandler.ChooseLanguage(user.Language, "Tueday", "??????????????"), LanguageHandler.ChooseLanguage(user.Language, "Tu", "????") },
				{ LanguageHandler.ChooseLanguage(user.Language, "Wednesday", "??????????"), LanguageHandler.ChooseLanguage(user.Language, "Wed", "????") },
				{ LanguageHandler.ChooseLanguage(user.Language, "Thisday", "??????????????"), LanguageHandler.ChooseLanguage(user.Language, "Th", "????") },
				{ LanguageHandler.ChooseLanguage(user.Language, "Friday", "??????????????"), LanguageHandler.ChooseLanguage(user.Language, "Fr", "??????") },
				{ LanguageHandler.ChooseLanguage(user.Language, "Saturday", "??????????????"), LanguageHandler.ChooseLanguage(user.Language, "Sat", "????") },
				{ LanguageHandler.ChooseLanguage(user.Language, "Sunday", "??????????????????????"), LanguageHandler.ChooseLanguage(user.Language, "Sun", "??????") }
			}));
			var	lastDay = beginMonthDay.Day <= endMonthDay.Day;
			var	calendarRows = (((int)beginMonthDay.DayOfWeek - 1) + endMonthDay.Day) / 7 + 1;

			for (int i = 0; i < calendarRows; ++i)
			{
				var	days = new Dictionary<string, string>();

				for (int j = 1; j <= 7; ++j)
				{
					if ((i + 1) * j >= (int)beginMonthDay.DayOfWeek && lastDay)
					{
						days.Add($"Date {beginMonthDay.ToShortDateString()}", beginMonthDay.Day.ToString());
						if (beginMonthDay.Day != endMonthDay.Day)
						{
							beginMonthDay = beginMonthDay.AddDays(1);
							lastDay = beginMonthDay.Day <= endMonthDay.Day;
						}
						else
							lastDay = false;
					}
					else
						days.Add($"{LanguageHandler.ChooseLanguage(user.Language, "Empty", "??????????")} {j * (i + 1)}", " ");
				}
				inlineKeyboard.Add(InlineKeyboard.GetInlineKeyboardLine(days));
			}
			inlineKeyboard.Add(InlineKeyboard.GetInlineKeyboardLine(new Dictionary<string, string>
			{
				{ "save-date", $"{LanguageHandler.ChooseLanguage(user.Language, "Save", "??????????????????")} {Stickers.Save}" },
				{ "cancel-date", $"{LanguageHandler.ChooseLanguage(user.Language, "Cancel", "????????????????")} {Stickers.Cancel}" }
			}));
			inlineKeyboard.Add(InlineKeyboard.GetInlineKeyboardLine(new Dictionary<string, string>
			{
				{ "clear-date", $"{LanguageHandler.ChooseLanguage(user.Language, "Clear", "????????????????")} {Stickers.Clear}" }
			}));
			return (inlineKeyboard);
		}
  }
}