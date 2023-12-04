namespace ModelAPI
{
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using CadApplication = Autodesk.AutoCAD.ApplicationServices.Core.Application;
    using GrillPlugin.Model;
    using Autodesk.AutoCAD.Geometry;

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
            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;

            using (var transaction = database.TransactionManager.StartTransaction())
            {
                var blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead)
                    as BlockTable;

                var blockTableRecords =
                    transaction.TransactionManager
                        .GetObject(
                            blockTable[BlockTableRecord.ModelSpace],
                            OpenMode.ForWrite) as BlockTableRecord;

                var circle = new Circle();
                circle.Radius = 1;
                circle.Center = new Point3d(0, 0, 0);

                blockTableRecords?.AppendEntity(circle);
                transaction.AddNewlyCreatedDBObject(circle, true);
                transaction.Commit();
            }
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
