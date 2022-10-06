using Microsoft.AspNetCore.Mvc;
using servicePeer.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;

namespace servicePeer.Controllers
{
    /// <summary>
    /// Класс для работы со списком пользователей.
    /// </summary>
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Список пользователей.
        /// </summary>
        internal static List<User> users = new List<User>();

        /// <summary>
        /// Возвращает кол-во пользователей.
        /// </summary>
        public static int UsersCount => users.Count;

        /// <summary>
        /// Обработчик для получения всего списка пользователей.
        /// </summary>
        /// <returns> Весь список пользоваетелей.</returns>
        [HttpGet]
        public IEnumerable<User> Get() => users;

        /// <summary>
        /// Обработчик для получения информации о пользователе по его идентификатору.
        /// </summary>
        /// <returns> Весь список пользоваетелей.</returns>
        [HttpGet("{Email}")]
        public IActionResult Get(string Email)
        {
            var user = users.SingleOrDefault(p => p.Email == Email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Создание списка пользователей.
        /// </summary>
        /// <returns> Результат действия.</returns>
        [HttpPost]
        public IActionResult Post()
        {
            Random rnd = new Random();
            var count = rnd.Next(1, 16);
            List<User> users = new();
            for (int i = 0; i < count; i++)
            {
                var email = WordGenerator.GetWord() + "@" + WordGenerator.GetWord() + ".ru";
                foreach (var item in users)
                {
                    if (item.Email == email)
                        continue;
                }
                users.Add(new Models.User() { Email = email, UserName = WordGenerator.GetWord() });
            }
            UsersController.users = users;
            SaveUsers();
            return Created(nameof(Get), users);
        }

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <returns> Результат действия.</returns>
        [HttpPost("{Email}/{Name}")]
        public IActionResult Post(string Email, string Name)
        {
            foreach (var item in users)
            {
                if (item.Email == Email)
                    return Ok(new { message = "такой email уже существует" });
            }
            users.Add(new User() { Email = Email, UserName = Name});
            SaveUsers();
            return Created(nameof(Get), users);
        }

        /// <summary>
        /// Метод для чтения списка пользователей из JSON файла 
        /// </summary>
        public static void ReadUsers()
        {
            try
            {
                var fileName = "Users.json";
                var jsonString = System.IO.File.ReadAllText(fileName);
                users = JsonSerializer.Deserialize<List<User>>(jsonString);
                foreach (var item in users)
                {
                    if (item.Email == null || item.UserName == null)
                        throw new System.Exception();
                }
            }
            catch (System.Exception)
            {
                users = new List<User>();
            }
        }

        /// <summary>
        /// Метод для записи списка пользователей в JSON файл (сортировка по Email по возрастанию)
        /// </summary>
        public static void SaveUsers()
        {
            try
            {
                users = users.OrderBy(x => x.Email).ToList();
                string fileName = "Users.json";
                string jsonString = JsonSerializer.Serialize(users);
                System.IO.File.WriteAllText(fileName, jsonString);
            }
            catch (System.Exception)
            {

            }
        }
    }
}
