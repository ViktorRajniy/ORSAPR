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

        public bool BuildGrill()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;

            using (Transaction trans = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction())
            {
                BlockTableRecord MdlSpc = (BlockTableRecord)trans.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(database), Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite, false, true);

                var grillBox = BuildGrillBox(
                    _parameters.GetParameter(ParameterType.BoxLength).Value,
                    _parameters.GetParameter(ParameterType.BoxWidth).Value,
                    _parameters.GetParameter(ParameterType.BoxHeight).Value);

                MdlSpc.AppendEntity(grillBox);
                trans.AddNewlyCreatedDBObject(grillBox, true);

                trans.Commit();
            }

            return true;
        }

        private Solid3d BuildGrillBox(double length, double width, double height)
        {
            // Объявление коллекции кривых
            DBObjectCollection curves = new DBObjectCollection();
            // Объявление коллекции регионов
            DBObjectCollection regions = new DBObjectCollection();

            // Объявление ДаблКолекшн в котором хранится количество элементов?
            double[] DblBulges = new double[4];
            DoubleCollection d = new DoubleCollection(DblBulges);

            // Массив точек основания мангала
            Point3d[] points = new Point3d[4]
            {
                new Point3d(-width / 2, -length / 2, 0),
                new Point3d(width / 2, -length / 2, 0),
                new Point3d(width / 2, length / 2, 0),
                new Point3d(-width / 2, length / 2, 0)
            };

            // Коллекция точек
            Point3dCollection pointCollection = new Point3dCollection(points);

            // Объявление 2д полигона
            Polyline2d boxBasePolyline = new Polyline2d(Poly2dType.SimplePoly, pointCollection, 0, false, 0, 0, d);

            curves.Add(boxBasePolyline);
            regions = Region.CreateFromCurves(curves);
            Region boxBase = (Region)regions[0];

            // Объявление коробки
            Solid3d box = new Solid3d();

            box.Extrude(boxBase, height, 0);

            return box;
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
