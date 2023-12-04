namespace GrillPlugin.Model
{
    // using Autodesk.AutoCAD.ApplicationServices;
    // using Autodesk.AutoCAD.DatabaseServices;
    using System.Windows.Forms;
    using Autodesk.AutoCAD.Runtime;
    using ModelAPI;

    /// <summary>
    /// Обёртка для работы с API.
    /// </summary>
    public class AutoCadWrapper
    {
        /// <summary>
        /// Команда вызывающая запуск плагина.
        /// </summary>
        [CommandMethod("Grill")]
        public void StartPlaguin()
        {
            GrillPluginForm grillPluginForm = new GrillPluginForm();
            DialogResult dialogResult = grillPluginForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                BuildGrill(grillPluginForm.parameters);
            }
        }

        public void BuildGrill(Parameters parameters)
        {
            AutoCadBuilder builder = new AutoCadBuilder(parameters);
            builder.BuildGrill();
        }
    }
}