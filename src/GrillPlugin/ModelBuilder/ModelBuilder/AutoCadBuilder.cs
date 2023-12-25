namespace ModelAPI
{
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using GrillPlugin.Model;
    using Autodesk.AutoCAD.Geometry;
    using ModelBuilder;

    /// <summary>
    /// Класс строитель мангала.
    /// </summary>
    public class AutoCadBuilder
    {
        /// <summary>
        /// Параметры мангала.
        /// </summary>
        private readonly Parameters _parameters;

        /// <summary>
        /// Конструктор класса с вложенными параметрами.
        /// </summary>
        /// <param name="parameters"> словарь с параметрами модели. </param>
        public AutoCadBuilder(Parameters parameters)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// Основной метод. Строит весь мангал.
        /// </summary>
        /// <returns></returns>
        public bool BuildGrill()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var database = document.Database;
            using (DocumentLock documentLock = document.LockDocument())
            {
                using (Transaction trans =
                    Autodesk.AutoCAD.ApplicationServices.Application.
                    DocumentManager.MdiActiveDocument.Database.
                    TransactionManager.StartTransaction())
                {
                    BlockTableRecord MdlSpc =
                        (BlockTableRecord)trans.
                        GetObject(SymbolUtilityServices.GetBlockModelSpaceId(database),
                        Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite, false, true);

                    Solid3d legs = BuildGrillLegs(
                        _parameters.GetParameter(ParameterType.LegHeight).Value,
                        _parameters.GetParameter(ParameterType.LegDiameter).Value,
                        _parameters.GetParameter(ParameterType.BoxLength).Value,
                        _parameters.GetParameter(ParameterType.BoxWidth).Value);

                    Solid3d grillBox = BuildGrillBox(
                        _parameters.GetParameter(ParameterType.BoxLength).Value,
                        _parameters.GetParameter(ParameterType.BoxWidth).Value,
                        _parameters.GetParameter(ParameterType.BoxHeight).Value,
                        _parameters.GetParameter(ParameterType.BoxWallThickness).Value,
                        _parameters.GetParameter(ParameterType.LegHeight).Value);

                    Point3d startPoint = new Point3d(
                        0,
                        _parameters.GetParameter(ParameterType.BoxWidth).Value / 2,
                        _parameters.GetParameter(ParameterType.HoleHeight).Value +
                        _parameters.GetParameter(ParameterType.LegHeight).Value
                        );

                    Solid3d holes = BuildCircleArray(
                        startPoint,
                        _parameters.GetParameter(ParameterType.HoleDiameter).Value,
                        _parameters.GetParameter(ParameterType.HoleDistance).Value,
                        _parameters.GetHoleCount(),
                        _parameters.GetParameter(ParameterType.BoxWidth).Value);

                    startPoint = new Point3d(
                        0,
                        _parameters.GetParameter(ParameterType.BoxWidth).Value / 2,
                        _parameters.GetParameter(ParameterType.BoxHeight).Value +
                        _parameters.GetParameter(ParameterType.LegHeight).Value
                        );

                    Solid3d slots = BuildCircleArray(
                        startPoint,
                        _parameters.GetParameter(ParameterType.GrooveDiameter).Value,
                        _parameters.GetParameter(ParameterType.GrooveDistance).Value,
                        _parameters.GetGrooveCount(),
                        _parameters.GetParameter(ParameterType.BoxWidth).Value);

                    Solid3d grill = new Solid3d();
                    grill.BooleanOperation(BooleanOperationType.BoolUnite, legs);
                    grill.BooleanOperation(BooleanOperationType.BoolUnite, grillBox);
                    grill.BooleanOperation(BooleanOperationType.BoolSubtract, holes);
                    grill.BooleanOperation(BooleanOperationType.BoolSubtract, slots);

                    MdlSpc.AppendEntity(grill);
                    trans.AddNewlyCreatedDBObject(grill, true);

                    trans.Commit();
                }
            }

            return true;
        }

        /// <summary>
        /// Метод строит короб мангала.
        /// </summary>
        /// <param name="boxLength">Длина короба мангала.</param>
        /// <param name="boxWidth">Ширина короба мангала.</param>
        /// <param name="boxHeight">Высота короба мангала.</param>
        /// <param name="boxThickness">Толщина стен мангала.</param>
        /// <param name="height">Высота положения короба.</param>
        /// <returns></returns>
        private Solid3d BuildGrillBox(
            double boxLength,
            double boxWidth,
            double boxHeight,
            double boxThickness,
            double height)
        {
            Region boxBase = SketchBuilder.CreateRectangle(
                boxWidth, 
                boxLength, 
                new Point3d(0, 0, height));

            Solid3d box = new Solid3d();

            Region boxCutter = SketchBuilder.CreateRectangle(
                boxWidth - (2 * boxThickness), 
                boxLength - (2 * boxThickness), 
                new Point3d(0, 0, height + boxThickness));

            Solid3d cutter = new Solid3d();

            box.Extrude(boxBase, -boxHeight, 0);

            cutter.Extrude(boxCutter, -boxHeight, 0);

            box.BooleanOperation(BooleanOperationType.BoolSubtract, cutter);

            return box;
        }

        /// <summary>
        /// Метод строит 4 ножки мангала.
        /// </summary>
        /// <param name="height">Высота ножек мангала.</param>
        /// <param name="diameter">Диаметр ножек мангала.</param>
        /// <param name="boxLength">Длина ножек мангала.</param>
        /// <param name="boxWidth">Ширина ножек мангала.</param>
        /// <returns></returns>
        private Solid3d BuildGrillLegs(
            double height,
            double diameter,
            double boxLength,
            double boxWidth)
        {
            Solid3d legs = new Solid3d();

            Point3d[] centers = new Point3d[4]
            {
                new Point3d((boxLength - diameter)/2, (boxWidth - diameter)/2, 0),
                new Point3d((boxLength - diameter)/2, -(boxWidth - diameter)/2, 0),
                new Point3d(-(boxLength - diameter)/2, -(boxWidth - diameter)/2, 0),
                new Point3d(-(boxLength - diameter)/2, (boxWidth - diameter)/2, 0)
            };

            for (int i = 0; i < 4; i++)
            {
                Solid3d leg = BuildGrillLeg(height, diameter, centers[i]);

                legs.BooleanOperation(BooleanOperationType.BoolUnite, leg);
            }

            return legs;
        }

        /// <summary>
        /// Метод строит 1 ножку мангала.
        /// </summary>
        /// <param name="height">Высота ножки.</param>
        /// <param name="diameter">Диаметр ножки мангала.</param>
        /// <param name="center">Положение ножки мангала.</param>
        /// <returns></returns>
        private Solid3d BuildGrillLeg(
            double height,
            double diameter,
            Point3d center)
        {
            Region circle = SketchBuilder.CreateCircle(center, Vector3d.ZAxis, diameter / 2);

            Solid3d leg = new Solid3d();

            leg.Extrude(circle, height, 0);

            return leg;
        }

        /// <summary>
        /// Метод создаёт массив горизонтально направленных цилиндров.
        /// </summary>
        /// <param name="diameter">Диаметр отверстия.</param>
        /// <param name="distance">Расстояние между отверстиями.</param>
        /// <param name="count">Количество отверстий.</param>
        /// <param name="deep">Глубина выреза.</param>
        /// <param name="height">Высота центра отверстия.</param>
        /// <returns></returns>
        private Solid3d BuildCircleArray(
            Point3d startPoint, 
            double diameter, 
            double distance, 
            int count, 
            double deep)
        {
            Solid3d circleArray = new Solid3d();

            int parity = count % 2;

            Point3d nextPoint = new Point3d();

            Solid3d cylinder = new Solid3d();

            double side = 1;

            if (parity != 0)
            {
                cylinder = BuildHorisontalCylinder(startPoint, diameter, deep);

                circleArray.BooleanOperation(BooleanOperationType.BoolUnite, cylinder);

                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < (count / 2) + 1; i++)
                    {
                        nextPoint = new Point3d(
                            startPoint.X + (side * (i * (diameter + distance))),
                            startPoint.Y,
                            startPoint.Z);

                        cylinder = BuildHorisontalCylinder(
                            nextPoint, 
                            diameter, 
                            deep);

                        circleArray.BooleanOperation(
                            BooleanOperationType.BoolUnite, 
                            cylinder);
                    }

                    side *= -1;
                }
            }
            else
            {
                Point3d start = new Point3d();

                for (int j = 0; j < 2; j++)
                {
                    start = new Point3d(
                    startPoint.X + (side * ((distance / 2) + (diameter / 2))),
                    startPoint.Y,
                    startPoint.Z);

                    for (int i = 0; i < count / 2; i++)
                    {
                        nextPoint = new Point3d(
                            start.X + (side * (i * (diameter + distance))),
                            start.Y,
                            start.Z);

                        cylinder = BuildHorisontalCylinder(
                            nextPoint, 
                            diameter, 
                            deep);

                        circleArray.BooleanOperation(
                            BooleanOperationType.BoolUnite, 
                            cylinder);
                    }

                    side *= -1;
                }
            }

            return circleArray;
        }

        /// <summary>
        /// Метод строит горизонтальный цилиндр по заданным параметрам.
        /// </summary>
        /// <param name="center">Центр окружности начала.</param>
        /// <param name="diameter">Диаметр цилиндра.</param>
        /// <param name="deep">Глубина цилиндра.</param>
        /// <returns></returns>
        private Solid3d BuildHorisontalCylinder(
            Point3d center, 
            double diameter,
            double deep)
        {
            Solid3d cylinder = new Solid3d();

            Region circle = SketchBuilder.CreateCircle(
                center, 
                Vector3d.YAxis, 
                diameter);

            cylinder.Extrude(circle, -deep, 0);

            return cylinder;
        }
    }
}
