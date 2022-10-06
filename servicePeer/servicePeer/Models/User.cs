using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace servicePeer.Models
{
    /// <summary>
    /// Класс, содержащий информацию о пользователе.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [JsonInclude]
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// Почтовый адрес пользователя. 
        /// </summary>
        [JsonInclude]
        [Required]
        public string Email { get; set; }
    }
}
