using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace servicePeer.Controllers
{
    /// <summary>
    /// Класс для работы со списком сообщений.
    /// </summary>
    [Route("/api/[controller]")]
    public class MessagesController : Controller
    {
        /// <summary>
        /// Список всех сообщений.
        /// </summary>
        private static List<Models.Letter> messages;

        /// <summary>
        /// Обработчик для получения всего списка сообщений.
        /// </summary>
        /// <returns> Весь список сообщений.</returns>
        [HttpGet]
        public IEnumerable<Models.Letter> Get() => messages;

        /// <summary>
        /// Создание списка сообщений.
        /// </summary>
        /// <returns> Результат действия.</returns>
        [HttpPost]
        public IActionResult Post()
        {
            if (UsersController.UsersCount <= 1)
                return NoContent();
            Random rnd = new Random();
            var count = rnd.Next(1, 20);
            List<Models.Letter> messages = new();
            for (int i = 0; i < count; i++)
            {
                var message = WordGenerator.GetWord() + WordGenerator.GetWord() + WordGenerator.GetWord();
                int sender = rnd.Next(0, UsersController.UsersCount);
                int receiver = rnd.Next(0, UsersController.UsersCount);
                if (sender == receiver)
                    continue;
                messages.Add(new Models.Letter() { Subject = WordGenerator.GetWord(), Message = message, ReceiverId = UsersController.users[receiver].Email, SenderId = UsersController.users[sender].Email });
            }
            MessagesController.messages = messages;
            SaveMessages();
            return Created(nameof(Get), messages);
        }

        /// <summary>
        /// Обработчик для получения списка сообщений по id отправителя и получателя.
        /// </summary>
        /// <returns> Весь список пользоваетелей.</returns>
        [HttpGet("{SenderEmail}/SenderAndReceiver/{ReceiverEmail}")]
        public IActionResult Get(string SenderEmail, string ReceiverEmail)
        {
            List<Models.Letter> letters = new();
            foreach (var message in messages)
            {
                if (message.ReceiverId == ReceiverEmail && message.SenderId == SenderEmail)
                    letters.Add(message);
            }
            return Ok(letters);
        }

        /// <summary>
        /// Обработчик для получения списка сообщений по id отправителя.
        /// </summary>
        /// <returns> Весь список пользоваетелей.</returns>
        [HttpGet("{SenderEmail}/Sender")]
        public IActionResult GetBySenderEmail(string SenderEmail)
        {
            List<Models.Letter> letters = new();
            foreach (var message in messages)
            {
                if (message.SenderId == SenderEmail)
                    letters.Add(message);
            }
            return Ok(letters);
        }

        
        /// <summary>
        /// Обработчик для получения списка сообщений по id получателя.
        /// </summary>
        /// <returns> Весь список пользоваетелей.</returns>
        [HttpGet("{ReceiverEmail}/Receiver")]
        public IActionResult GetByReceiverEmail(string ReceiverEmail)
        {
            List<Models.Letter> letters = new();
            foreach (var message in messages)
            {
                if (message.ReceiverId == ReceiverEmail)
                    letters.Add(message);
            }
            return Ok(letters);
        }

        /// <summary>
        /// Метод для чтения списка сообщений из JSON файла.
        /// </summary>
        public static void ReadMessages()
        {
            try
            {
                var fileName = "Messages.json";
                var jsonString = System.IO.File.ReadAllText(fileName);
                messages = JsonSerializer.Deserialize<List<Models.Letter>>(jsonString);
                foreach (var item in messages)
                {
                    if (item.Message == null || item.Subject == null || item.ReceiverId == null || item.SenderId == null)
                        throw new System.Exception();
                }
            }
            catch (System.Exception)
            {
                messages = new List<Models.Letter>();
            }
        }

        /// <summary>
        /// Метод для записи списка сообщений в JSON файл.
        /// </summary>
        public static void SaveMessages()
        {
            try
            {
                string fileName = "Messages.json";
                string jsonString = JsonSerializer.Serialize(messages);
                System.IO.File.WriteAllText(fileName, jsonString);
            }
            catch (System.Exception)
            {

            }
        }
    }
}
