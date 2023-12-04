namespace GrillPlugin.Model
{
    // using Autodesk.AutoCAD.ApplicationServices;
    // using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Runtime;

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