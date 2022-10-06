using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace servicePeer.Models
{
    /// <summary>
    /// Класс, содержащий информацию о письме.
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Тема сообщения.
        /// </summary>
        [Required]
        public string Subject { get; set; }
        /// <summary>
        /// Сообщение.
        /// </summary>
        [Required]
        public string Message { get; set; }
        /// <summary>
        /// ID отправителя.
        /// </summary>
        [Required]
        public string SenderId { get; set; }
        /// <summary>
        /// ID получателя.
        /// </summary>
        [Required]
        public string ReceiverId { get; set; }
    }
}
