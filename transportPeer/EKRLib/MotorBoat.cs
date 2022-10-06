namespace EKRLib
{
    /// <summary>
    /// Класс, описывающий моторную лодку.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор с 2 параметрами: model, power.
        /// </summary>
        /// <param name="model"> Название модели.</param>
        /// <param name="power"> Мощность.</param>
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Метод для получения звука (в виде строки), издаваемого транспортным средством.
        /// </summary>
        /// <returns> Звук (в виде строки), издаваемый транспортным средством.</returns>
        public override string StartEngine()
        {
            return $"{model}: Brrrbrr";
        }

        /// <summary>
        /// Переопределенный метод ToString().
        /// </summary>
        /// <returns> Строка формата "model: {model}, power: {power}".</returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }
    }
}
