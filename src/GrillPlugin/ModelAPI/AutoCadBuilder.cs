namespace ModelAPI
{
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    // using Autodesk.AutoCAD.Geometry;
    using CadApplication = Autodesk.AutoCAD.ApplicationServices.Core.Application;
    using GrillPlugin.Model;
    // using Autodesk.AutoCAD.Geometry;

    /// <summary>
    /// Класс строитель мангала.
    /// </summary>
    public class AutoCadBuilder
    {
        private readonly Parameters _parameters;

        /// <summary>
        /// Активный документ (чертеж) в AutoCAD.
        /// </summary>
        private Document _document;

        /// <summary>
        /// База данных документа.
        /// </summary>
        private Database _database;

        /// <summary>
        /// Конструктор класса с вложенными параметрами.
        /// </summary>
        /// <param name="parameters"> словарь с параметрами модели. </param>
        public AutoCadBuilder(Parameters parameters)
        {
            _parameters = parameters;
            InitialSetting();
        }

        public void BuildGrill()
        {
        }

        private Solid3d BuildGrillBox()
        {
            return new Solid3d();
        }

        /// <summary>
        /// Преднастройка.
        /// </summary>
        private void InitialSetting()
        {
            _document = CadApplication.DocumentManager.MdiActiveDocument;
            _database = _document.Database;

            _database.Insunits = UnitsValue.Millimeters;
        }
    }
}
