namespace EKRLib
{
    /// <summary>
    /// Класс Transport описывает абстрактное транспортное средство.
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Приватное поле для названия модели.
        /// </summary>
        private string modelField;

        /// <summary>
        /// Приватное поле для мощности.
        /// </summary>
        private uint powerField;

        /// <summary>
        /// Приватное свойство для названия модели.
        /// </summary>
        private protected string model
        {
            get
            {
                return modelField;
            }
            set
            {
                if (!CheckModel(value))
                    throw new TransportException($"Недопустимая модель {value}");
                modelField = value;
            }
        }

        /// <summary>
        /// Приватное свойство для мощности.
        /// </summary>
        private protected uint power //что будет если запихать в инт НЕ инт??
        {
            get
            {
                return powerField;
            }
            set
            {
                if (value < 20)
                    throw new TransportException("мощность не может быть меньше 20 л.с.");
                powerField = value;
            }
        }

        /// <summary>
        /// Конструктор с 2 параметрами: modelField, powerField.
        /// </summary>
        /// <param name="modelField"> Название модели.</param>
        /// <param name="powerField"> Мощность.</param>
        public Transport(string modelField, uint powerField)
        {
            model = modelField;
            power = powerField;
        }

        /// <summary>
        /// Метод для получения звука (в виде строки), издаваемого транспортным средством.
        /// </summary>
        /// <returns> Звук (в виде строки), издаваемый транспортным средством.</returns>
        public abstract string StartEngine();

        /// <summary>
        /// Проверят корректность названия модели.
        /// </summary>
        /// <param name="modelField"> Название модели.</param>
        /// <returns> true - при корректном названии, false - в противном случае.</returns>
        private bool CheckModel(string modelField)
        {
            if (modelField.Length != 5)
                return false;
            foreach (var symbol in modelField)
            {
                if (!char.IsDigit(symbol) && !char.IsUpper(symbol))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Переопределенный метод ToString().
        /// </summary>
        /// <returns> Строка формата "model: {model}, power: {power}".</returns>
        public override string ToString()
        {
            return $"model: {model}, power: {power}";
        }
    }
}
