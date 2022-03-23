using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SquareExercise.DependencyInjectionClass.Repository;
using SquareExercise.Interface;
using SquareExercise.Models;
using SquareExercise.SqlLiteRepository;

namespace SquareExercise.PerfectSquareService
{
    public class PerfectSquareService : IShapeService
    {
        private readonly RepositoryQueryCalls _repositoryQueryCalls;

        public PerfectSquareService()
        {
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
        }

        private bool ValidateShapeByCoordinates(PerfectSquareModel squareModel)
        {
            bool isSquare;

            double aPointX = squareModel.PointA.CoordinateX;
            double aPointY = squareModel.PointA.CoordinateY;

            double bPointX = squareModel.PointB.CoordinateX;
            double bPointY = squareModel.PointB.CoordinateY;

            double cPointX = squareModel.PointC.CoordinateX;
            double cPointY = squareModel.PointC.CoordinateY;

            double dPointX = squareModel.PointD.CoordinateX;
            double dPointY = squareModel.PointD.CoordinateY;

            double distancePointAToB = CountDistance(firstXPoint: aPointX, firstYPoint: aPointY, secondXPoint: bPointX,
                secondYPoint: bPointY);
            double distancePointAToC = CountDistance(firstXPoint: aPointX, firstYPoint: aPointY, secondXPoint: cPointX,
                secondYPoint: cPointY);
            double distanceAToD = CountDistance(firstXPoint: aPointX, firstYPoint: aPointY, secondXPoint: dPointX,
                secondYPoint: dPointY);

            double distanceBToC = CountDistance(firstXPoint: bPointX, firstYPoint: bPointY, secondXPoint: cPointX,
                secondYPoint: cPointY);
            double distanceBToD = CountDistance(firstXPoint: bPointX, firstYPoint: bPointY, secondXPoint: dPointX,
                secondYPoint: dPointY);

            double distanceCToD = CountDistance(firstXPoint: cPointX, firstYPoint: cPointY, secondXPoint: dPointX,
                secondYPoint: dPointY);

            List<double> distanceList = new List<double>();
            distanceList.Add(distancePointAToB);
            distanceList.Add(distancePointAToC);
            distanceList.Add(distanceAToD);

            distanceList.Add(distanceBToC);
            distanceList.Add(distanceBToD);

            distanceList.Add(distanceCToD);

            if (distancePointAToB == 0 || distancePointAToC == 0 || distanceAToD == 0 || distanceBToC == 0 || distanceBToD == 0 || distanceCToD == 0)
            {
                return false;
            }

            List<double> removeSameValues = new List<double>();

            removeSameValues = distanceList.Distinct().ToList();

            if (removeSameValues.Count == 2)
            {
                isSquare = true;
            }
            else
            {
                isSquare = false;
            }

            return isSquare;
        }

        public bool ValidateShapeByCoordinates()
        {
            throw new NotImplementedException();
        }

        public List<CountPerfectSquareModel> GetAllPointPossibilities(List<PointModel> coordinatesList)
        {
            var possibleSquareList = new List<PerfectSquareModel>();
            var list = FillListWithCoordinates(coordinatesList);
            var shapeList = CountDistanceWithDots(list);
            return shapeList;
        }

        private double CountDistance(double firstXPoint, double secondXPoint, double firstYPoint, double secondYPoint)
        {
            double distance =
                Math.Sqrt((Math.Pow(firstXPoint - secondXPoint, 2) + Math.Pow(firstYPoint - secondYPoint, 2)));
            return distance;
        }

        private List<CountPerfectSquareModel> CountDistanceWithDots(List<PerfectSquareModel> squarePossibilityList)
        {
            List<CountPerfectSquareModel> squareList = new List<CountPerfectSquareModel>();

            foreach (var square in squarePossibilityList)
            {
                var squareModel = new PerfectSquareModel()
                {
                    PointA = square.PointA,
                    PointB = square.PointB,
                    PointC = square.PointC,
                    PointD = square.PointD
                };

                var countPerfectSquareModel = new CountPerfectSquareModel()
                {
                    PointA = square.PointA,
                    PointB = square.PointB,
                    PointC = square.PointC,
                    PointD = square.PointD,
                    IsPossible = ValidateShapeByCoordinates(squareModel)
                };

                squareList.Add(countPerfectSquareModel);
            }

            return squareList;
        }

        private List<PerfectSquareModel> FillListWithCoordinates(List<PointModel> coordinateList)
        {
            List<PerfectSquareModel> newList = new List<PerfectSquareModel>();

            int countOfCoordinates = coordinateList.Count;

            if (countOfCoordinates >= 4)
            {
                while (true)
                {
                    int indexElement = 1;
                    for (int i = 4; i <= countOfCoordinates; i++)
                    {

                        var takeCoordinates = new PerfectSquareModel()
                        {
                            PointA = coordinateList[0],
                            PointB = coordinateList[indexElement],
                            PointC = coordinateList[indexElement + 1],
                            PointD = coordinateList[indexElement + 2]
                        };

                        newList.Add(takeCoordinates);
                        indexElement++;
                    }

                    coordinateList.RemoveAt(0);
                    countOfCoordinates = coordinateList.Count;

                    if (countOfCoordinates < 4)
                    {
                        break;
                    }
                }
            }
            else
            {
                newList = null;
            }

            return newList;

        }
    }
}
