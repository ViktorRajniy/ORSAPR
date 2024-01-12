namespace ModelAPI
{
    using Autodesk.AutoCAD.Runtime;
    using View;

    /// <summary>
    /// Обёртка для работы с API.
    /// </summary>
    public class AutoCadConnector
    {
        /// <summary>
        /// Команда вызывающая запуск плагина.
        /// </summary>
        [CommandMethod("Grill")]
        public void StartPlaguin()
        {
            GrillPluginForm grillPluginForm = new GrillPluginForm();
            grillPluginForm.Show();
        }
    }
}